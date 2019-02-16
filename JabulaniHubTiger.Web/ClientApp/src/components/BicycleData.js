import React, { Component } from 'react';
import NETCALL from '../components/common/NetWorkCall';
import NetWorkMethods from '../components/common/NetWorkMethods';
import FetchData from '../components/FetchData';

export default class BicycleData extends Component {
    static displayName = BicycleData.name;

    constructor(props) {
        super(props);
        this.state = { model: "", bicyleCondition: "good",selectOptions: ["good","bad","worse"] };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleSelectchanged = this.handleSelectchanged.bind(this);
    }

    handleChange = (event) => {
        this.setState({ model: event.target.value });
    }

    handleSubmit = async (event) => {
        //alert('A bicycle has been added');
        try {
            const response = await NETCALL(NetWorkMethods.POST, "api/Bicycle/Post", { model: this.state.model, bicyleCondition: this.state.bicyleCondition });
            console.log("done", JSON.stringify(response));
        } catch (error) {
            console.log("error", JSON.stringify(error))
        }
        event.preventDefault();
    }

    handleSelectchanged = (event) => {
        this.setState({ bicyleCondition: event.target.value });
    }

  
    render() {
        return (
            <div>
                <h1>Add a new bicycle</h1>
                <form onSubmit={this.handleSubmit}>
                    <label className="col-md-4">
                        Name:
                        <input type="text" value={this.state.model} onChange={this.handleChange}></input>
                    </label>
                   
                    <label className="col-md-4">
                        Pick Bicycle condition
                        <select value={this.state.bicyleCondition} onChange={this.handleSelectchanged}>
                            {this.state.selectOptions.map(value => <option value={value} key={value}>{value}</option>)}
                        </select>
                    </label>
                    <div className="row" >
                        <input className="btn btn-primary" type="submit" value="Submit" />
                    </div>
                </form>
                <FetchData />
            </div>
        );
    }
}