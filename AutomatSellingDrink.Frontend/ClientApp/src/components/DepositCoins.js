import React, { Component } from 'react';

export class DepositCoins extends Component {
    static displayName = DepositCoins.name;
    //summ = 0;

    constructor(props) {
        super(props);
        this.state = {
            cost: 0,
        };
        this.depositcoins = this.depositcoins.bind(this);
    }

    OnChangeSumm = (e) =>{
            this.setState(
                {
                    cost: e.target.value
                });
    }

    static renderBalance(response) {
        return (
            <div>
                {
                    <span>{response.summ}</span>
                }
            </div>
        );
    }

    render() {
        let contents = DepositCoins.renderBalance(this.props.balance);

        return (
                <div>
                    {contents}
                    <input type="text" onChange={this.OnChangeSumm} value={this.state.cost}/>
                    <button onClick={this.depositcoins}>Пополнить баланс</button>
                </div>
        );
    }



    async depositcoins() {
        const requestOptions = {
            method: 'POST',
            withCredentials: true,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(
                {
                    "cost": this.state.cost
                }
            )
        };
        const response = await fetch('https://localhost:5001/UserAutomat/depositcoins',requestOptions);
        const data = await response.json();

        this.props.onBalanceChange(data);
       // DepositCoins.renderBalance(this.state);

    }
}
