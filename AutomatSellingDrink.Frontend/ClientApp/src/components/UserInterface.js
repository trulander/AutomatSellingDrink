import React, { Component } from 'react';

export class UserInterface extends Component {
    static displayName = UserInterface.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(getavailabledrinks) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Название напитка</th>
                    <th>Цена</th>
                    <th>ImageId</th>
                </tr>
                </thead>
                <tbody>
                {getavailabledrinks.map(drinks =>
                    <tr key={drinks.name}>
                        <td>{drinks.name}</td>
                        <td>{drinks.cost}</td>
                        <td>{drinks.fileId}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : UserInterface.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Автоман покупки напитков</h1>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('https://localhost:5001/UserAutomat/getavailabledrinks');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}
