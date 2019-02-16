import React, { Component } from 'react';
import NETCALL from '../components/common/NetWorkCall';
import NetWorkMethods from '../components/common/NetWorkMethods';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';

async function onAfterSaveCell(row, cellName, cellValue) {
    //alert(`Save cell ${cellName} with value ${cellValue}`);

    let rowStr = '';
    let count = 0;
    let data = { id: 0, model: "",createdOn:"", bicyleCondition: ""}
    for (const prop in row) {
        rowStr += prop + ': ' + row[prop] + '\n';
        switch (count) {
            case 0:
                data.id = row[prop];
                break;
            case 1:
                data.model = row[prop];
                break;
            case 2:
                data.createdOn = row[prop];
                break;
            case 3:
                data.bicyleCondition = row[prop];
                break;
            default:
        }
        count += 1;


    }
    try {
        const response = await NETCALL(NetWorkMethods.PUT, "api/Bicycle/Put", data);
        if (response.status === 200)
            alert('record up dated: \n' + rowStr);
    } catch (error) {

    }
    
}

function onBeforeSaveCell(row, cellName, cellValue) {
    // You can do any validation on here for editing value,
    // return false for reject the editing
    return true;
}


export default class FetchData extends Component {
  static displayName = FetchData.name;

  constructor (props) {
    super(props);
      this.state = {
          forecasts: [], loading: true, selectOptions: ["good", "bad", "worse"]  };

      //fetch('api/Bicycle/Post')
      //    .then(response => console.log("response",response))
      //.then(data => {
      //  this.setState({ forecasts: data, loading: false });
      //});
      this.postBicycle();
    }

    
    postBicycle = async () => {
        try
        {
            const response = await NETCALL(NetWorkMethods.GET, "api/Bicycle/GetAll", "");

            if (response.status === 200) {
                console.log("hghg", JSON.stringify(response.data.data));
                this.setState({ forecasts: response.data.data, loading: false });
            }
        } catch (error)
        {

        }
    }

 
    static renderForecastsTable(forecasts,options) {
        const cellEditProp = {
            mode: 'click',
            blurToSave: true,
            beforeSaveCell: onBeforeSaveCell, // a hook for before saving cell
            afterSaveCell: onAfterSaveCell  // a hook for after saving cell
        };
        return (
            <BootstrapTable
                data={forecasts}
                striped
                hover
                pagination
                exportCSV
                csvFileName='bikes-export'
                cellEdit={cellEditProp}>
                <TableHeaderColumn dataField='id' isKey>Id</TableHeaderColumn>
                <TableHeaderColumn dataField='model'>Model</TableHeaderColumn>
                <TableHeaderColumn dataField='bicyleCondition' editable={{ type: 'select', options: { values: options } }}>Condition</TableHeaderColumn>
            </BootstrapTable>
    );
  }

  render () {
    let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : FetchData.renderForecastsTable(this.state.forecasts, this.state.selectOptions);

    return (
      <div>
            <h1>List of Bicycles</h1>
            <h2>Click on the table to edit a cell</h2>
        {contents}
      </div>
    );
  }
}
