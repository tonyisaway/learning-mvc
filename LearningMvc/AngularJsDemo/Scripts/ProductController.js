(function () {
    var app = angular.module("productsapp", []);

    var ProductsController = function (scope, productsService) {
        
        scope.product = {
            Id: "",
            Name: "",
            Category: "",
            Price: ""
        };

        scope.products = [];

        var productIndex = null;

        var onError = function (ex) {
            scope.error = "There was an error.";
        };

        var onGetProductsSuccess = function (data) {
            scope.products = data;
        };

        var onDeleteProductSuccess = function (data) {
            if (data == true) {
                scope.products.splice(productIndex, 1);
                productIndex = null;
            }
        };

        var onUpdateProductSuccess = function (data) {
            scope.products = data;
            scope.clearProduct();
        };

        var onSaveProductSuccess = function (data) {
            scope.products.push(data);
            scope.clearProduct();
        }

        var getProducts = function () {
            productsService.getProducts()
                .then(onGetProductsSuccess, onError);
        };

        scope.editProduct = function (product) {
            scope.product = product;
        };

        scope.deleteProduct = function (index) {
            productIndex = index;
            var product = scope.products[index];
            productsService.deleteProduct(product.Id)
                .then(onDeleteProductSuccess, onError);
        };

        scope.updateProduct = function () {
            productsService.updateProduct(scope.product)
                .then(onUpdateProductSuccess, onError);
        };

        scope.saveProduct = function () {
            productsService.addProduct(scope.product)
                .then(onSaveProductSuccess, onError);
        };

        scope.cancelEdit = function () {
            scope.clearProduct();
        };

        scope.clearProduct = function () {
            scope.product = {
                Id: "",
                Name: "",
                Category: "",
                Price: ""
            };
        };

        scope.total = function () {
            var total = 0;
            angular.forEach(scope.products, function (item) {
                total += item.Price;
            });

            return total;
        }

        getProducts();
    };

    app.controller("productsController", ["$scope", "productsService", ProductsController]);
})();