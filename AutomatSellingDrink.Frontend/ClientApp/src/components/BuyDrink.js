import React, { Component } from 'react';

export class BuyDrink extends Component {
    static displayName = BuyDrink.name;
    //summ = 0;

    constructor(props) {
        super(props);
        this.state = {
            name: props.name,
        };
        this.depositcoins = this.depositcoins.bind(this);
    }

    render() {
        return (
                <div>
                    <button onClick={this.depositcoins}>Купить напиток</button>
                </div>
        );
    }


    async depositcoins() {
        const requestOptions = {
            method: 'POST',
            withCredentials: true,
            body: new FormData()
        };
        requestOptions.body.append('name', this.state.name);

        // for (let key in data) {
        //     requestOptions.body.append(key, data[key]);
        // }
        const response = await fetch('https://localhost:5001/UserAutomat/buyDrink', requestOptions);
        const data = await response.json();

        this.props.onDrinksChange(data);

    }
}
