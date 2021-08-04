import React, { Component } from 'react';
import {BuyDrink} from "./BuyDrink";
import axios from "axios";

export class DepositCoins extends Component {
    static displayName = DepositCoins.name;
    //summ = 0;

    constructor(props) {
        super(props);
        this.state = {
            cost: 0,
            coins: []
        };
        this.depositcoins = this.depositcoins.bind(this);
        this.LoadAllCoins = this.LoadAllCoins.bind(this);
    }

    componentDidMount() {
        this.LoadAllCoins();
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

    renderCoins(coins) {
        return (
            <div>
                {coins.map(coin =>
                    <button key={coin.cost}
                            disabled={!coin.isAllowToDeposit}
                            value={coin.cost}
                            onClick={this.depositcoins}
                    >пополнить на {coin.cost}</button>
                )}
            </div>
        );
    }

    render() {
        let balance = DepositCoins.renderBalance(this.props.balance);
        let coins = this.renderCoins(this.state.coins);

        return (
                <div>
                    {balance}
                    {coins}
                    {/*<input type="text" onChange={this.OnChangeSumm} value={this.state.cost}/>*/}
                    {/*<button onClick={this.depositcoins}>Пополнить баланс</button>*/}
                </div>
        );
    }



    async depositcoins(event) {
        const formData = {
            "cost": event.target.value
        }
        axios.post("https://localhost:5001/UserAutomat/depositcoin", formData)
            .then(res => {
                this.props.onBalanceChange(res.data);
            }).catch(error=> {
                if (error.response == undefined){
                    console.log(error.message);
                    this.setState({
                        error: error.message,
                        coins: []
                    });
                }else {
                    console.log(error.response.data.text);
                    this.setState({
                        error: error.response.data.text,
                    });
                }
            })
    }

    async LoadAllCoins() {
        axios.get("https://localhost:5001/UserAutomat/getallcoins")
            .then(res => {
                this.setState({
                    coins: res.data,
                });
            }).catch(error=> {
                if (error.response == undefined){
                    console.log(error.message);
                    this.setState({
                        error: error.message,
                        coins: []
                    });
                }else {
                    console.log(error.response.data.text);
                    this.setState({
                        error: error.response.data.text,
                        coins: []
                    });
                }
            })


    }
}
