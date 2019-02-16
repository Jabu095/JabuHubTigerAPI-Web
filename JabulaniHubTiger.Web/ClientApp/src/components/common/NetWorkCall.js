import axios from 'axios';

const NETCALL = async (method, url, data = null) => {
    try {
        console.log('perfoming network call ' + method + ' on ' + url);
        const response = await axios({
            method: method,
            url: url,
            data: data
        });
        console.log('networkingResponse' + JSON.stringify(response.status));
        if (response.status === 204) {
            return {
                status: 204,
                message: 'Not successfull',
                data: null
            };
        } else {
            return response;
        }
    } catch (erro) {
        console.log('networking error on' + url + ' what: ' + erro);
        return {
            status: erro.response === undefined ? 500 : erro.response.status,
            message: erro.response === undefined ? "Network ralated error" : erro.response.data.message,
            data: erro.response === undefined ? erro : erro.response.data
        };
    }
}

export default NETCALL;