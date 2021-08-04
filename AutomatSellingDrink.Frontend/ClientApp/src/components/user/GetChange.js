import React, { Component } from 'react';
import axios from 'axios';

export class GetChange extends Component {
    static displayName = GetChange.name;

    constructor(props) {
        super(props);
        this.state = {
            coins: [],
            error: ""
        };
        this.GetChange = this.GetChange.bind(this);
    }

    renderChange(coins) {
        return (
            <div>
                {coins.map(coin =>
                    <div key={"change" + coin.cost}>{coin.cost} : {coin.count}</div>
                )}
            </div>
        );
    }

    render() {
        return (
                <div style={{textAlign: "right"}}>
                    <button onClick={this.GetChange}>Забрать сдачу</button><br/>
                    {this.renderChange(this.state.coins)}
                </div>
        );
    }


    async GetChange() {
        axios.get("https://localhost:5001/UserAutomat/getchange")
            .then(res => {
                 this.setState({
                     coins: res.data,
                 });
                 this.props.onBalanceChange({summ: 0});
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
