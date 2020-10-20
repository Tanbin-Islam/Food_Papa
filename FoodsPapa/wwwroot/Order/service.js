app.service('myService', function ($http) {

    this.orderList = function () {
        var response = $http.get('OrderOnline/OrderList');
        return response;
    };

    this.addOrder = function (order) {
        //alert(Order);
        var response = $http({
            method: 'post',
            url: 'OrderOnline/AddOrder',
            data: JSON.stringify(order)
        });
        return response;
    };

    this.updateOrder = function (order) {
        //alert(oderonline);
        var response = $http({
            method: 'post',
            url: 'OrderOnline/UpdateOrder',
            data: JSON.stringify(order),
        });
        return response;
    };

    this.deleteOrder = function (id) {
        var response = $http({
            method: 'post',
            url: 'OrderOnline/DeleteOrder',
            params: { id: JSON.stringify(id) }
        });
        return response;
    };

});