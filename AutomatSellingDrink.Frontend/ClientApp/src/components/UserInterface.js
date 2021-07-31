import React, { Component } from 'react';
import {DepositCoins} from "./DepositCoins";
import {BuyDrink} from "./BuyDrink";

export class UserInterface extends Component {
    static displayName = UserInterface.name;

    constructor(props) {
        super(props);
        this.state = {
            cost: 0,
            balance: 0,
            drinks: []
        };
        this.handleBalanceChange = this.handleBalanceChange.bind(this);
        this.handleDrinksChange = this.handleDrinksChange.bind(this);
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderUserInterface(getavailabledrinks, handleDrinksChange) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Название напитка</th>
                    <th>Цена</th>
                    <th>В наличии</th>
                    <th>ImageId</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                {getavailabledrinks.map(drinks =>
                    <tr key={drinks.name}>
                        <td>{drinks.name}</td>
                        <td>{drinks.cost}</td>
                        <td>{drinks.count}</td>
                        <td>{drinks.fileId}</td>
                        <td><BuyDrink
                            name={drinks.name}
                            onDrinksChange={handleDrinksChange} />
                        </td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    handleBalanceChange(balance) {
        this.setState({
            balance: balance
        });
    }

    handleDrinksChange(balance) {
        this.setState({
            balance: balance
        });
        this.populateWeatherData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : UserInterface.renderUserInterface(this.state.drinks, this.handleDrinksChange);
        const balance = this.state.balance;
        return (
            <div>
                <h1 id="tabelLabel" >Автоман покупки напитков</h1>
                <DepositCoins
                    balance={balance}
                    onBalanceChange={this.handleBalanceChange} />
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('https://localhost:5001/UserAutomat/getavailabledrinks');
        const data = await response.json();
        this.setState({
            drinks: data,
            loading: false
        });
    }
}
