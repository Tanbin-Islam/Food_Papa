app.controller('myController', function ($scope, myService) {
    OrderList();
    $scope.newOrder = {};
    $scope.clickedOrder = {};
    $scope.message = "";

    function OrderList() {
        myService.orderList().then(function (result) {
            $scope.orderOnlines = result.data;
            console.log(result.data);
        });
    };

    $scope.addOrder = function () {
        myService.addOrder($scope.newOrder)
            .then(function (result) {
                $scope.newOrder = {};
                $scope.message = "Data saved successfully";
                OrderList()
                console.log(result.data);
            });

        //, function (result) {
        //    alert(result)
        //}
        //);

    };

    $scope.selectedOrder = function (order) {
        $scope.clickedOrder = order;
    };

    $scope.updateOrder = function () {


        myService.updateOrder($scope.clickedOrder).then(function (result) {
            $scope.message = "Data Update successfully";
            $scope.orderOnlines = result;
            OrderList();
        }, function (result) {
            alert(result);
        });

    };
    $scope.deleteOrder = function () {
        myService.deleteOrder($scope.clickedOrder.OrderId).then(function (result) {
            $scope.message = "Data Delete successfully";
            OrderList();
        }, function (result) {
            alert(result);
        });

    };
    $scope.clearInfo = function () {
        $scope.message = "";
    };

});