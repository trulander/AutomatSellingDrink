import React, { Component } from 'react';
import {DepositCoins} from "./admin/DepositCoins";
import {BuyDrink} from "./admin/BuyDrink";
import {GetChange} from "./admin/GetChange";
import { Formik, Field, Form } from 'formik';
import axios from "axios";

export class AdminInterface extends Component {
    static displayName = AdminInterface.name;

    constructor(props) {
        super(props);
        this.state = {
            cost: 0,
            balance: 0,
            drinks: []
        };
        this.handleBalanceChange = this.handleBalanceChange.bind(this);
        this.handleDrinksChange = this.handleDrinksChange.bind(this);
        this.renderUserInterface = this.renderUserInterface.bind(this);
    }

    componentDidMount() {
        this.LoadDataDrinks();
        this.LoadDataBalance();
    }


    renderUserInterface(getavailabledrinks, handleDrinksChange) {
        return (
            <>
               {getavailabledrinks.map((drinks, key, arr) =>(
                   <tr key={drinks.name}>
                        <td>
                            <Formik
                                initialValues={{
                                    cost: drinks.cost,
                                    name: drinks.name,
                                    fileId: drinks.fileId,
                                    file: '',
                                    count: drinks.count
                                }}
                                onSubmit={async (values) => {
                                    this.state.drinks[key] = values;
                                    this.updateDrink(key);
                                }}
                            >

                                <Form>
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td><Field name="cost" type="text" /></td>
                                                <td><Field name="name" type="text" /></td>
                                                <td><Field name="count" type="text" /></td>
                                                <td><img src={drinks.image.path} style={{maxWidth: 100}}/></td>
                                                <td><Field name="file" type="file" /></td>

                                                <td><button type="submit">Обновить</button></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </Form>

                            </Formik>
                        </td>
                   </tr>
                ))}
            </>
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
        this.LoadDataDrinks();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderUserInterface(this.state.drinks, this.handleDrinksChange);

        const balance = this.state.balance;
        return (
            <div>
                <h1 id="tabelLabel" >Автоман покупки напитков</h1>
                <GetChange
                    onBalanceChange={this.handleBalanceChange}/>
                <DepositCoins
                    balance={balance}
                    onBalanceChange={this.handleBalanceChange} />

                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <td>
                                <table className='table table-striped' aria-labelledby="tabelLabel">
                                    <tbody>
                                        <tr>
                                            <td>Количество</td>
                                            <td>Название напитка</td>
                                            <td>Цена</td>
                                            <td>Фото</td>
                                            <td>Загрузить фото</td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        {contents}
                    </tbody>
                </table>
            </div>
        );
    }

    async updateDrink(key) {


        axios.put("https://localhost:5001/AdminAutomat/updatedrink", this.state.drinks[key])
            .then(res => {
                this.state.drinks[key] = res.data;
                console.log(res);
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


    async LoadDataDrinks() {
        const response = await fetch('https://localhost:5001/AdminAutomat/getalldrinks');
        const data = await response.json();
        this.setState({
            drinks: data,
            loading: false
        });

    }

    async LoadDataBalance() {
        const response = await fetch('https://localhost:5001/UserAutomat/getbalance');
        const data = await response.json();
        this.handleDrinksChange(data);
    }
}
