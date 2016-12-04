(function () {

    var app = angular.module("productsapp");

    var ProductsService = function (http) {

        var productBaseUrl = "/api/Product/";
        var productsBaseUrl = "/api/Products/";

        var getProducts = function () {
            return http.get(productsBaseUrl + "Get")
                .then(function (response) {
                    return response.data;
                });
        };

        var getProduct = function (id) {
            return http.get(productBaseUrl + id)
                .then(function (response) {
                    return response.data;
                });
        };

        var deleteProduct = function (id) {
            return http.delete(productBaseUrl + id)
                .then(function (response) {
                    return response.data;
                });
        };

        var updateProduct = function (product) {
            return http.put(productBaseUrl + product.Id, product)
                .then(function (response) {
                    return response.data;
                });
        };

        var addProduct = function (product) {
            return http.post(productBaseUrl, product)
                .then(function (response) {
                    return response.data;
                });
        };

        return {
            getProducts: getProducts,
            getProduct: getProduct,
            deleteProduct: deleteProduct,
            updateProduct: updateProduct,
            addProduct: addProduct
        };
    };

    app.factory("productsService", ["$http", ProductsService]);

})();