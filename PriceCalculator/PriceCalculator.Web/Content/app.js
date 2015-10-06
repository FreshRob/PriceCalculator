(function () {
    'use strict';

    angular.module('app', ['ngRoute']).
    config(["$routeProvider", function ($routeProvider) {
        $routeProvider
        .when("/", { controller: "homeController", controllerAs: 'hm', template: "<div><ul><li ng-repeat='product in hm.products'>{{product.Name}} <button ng-click='hm.addToBasket(product)'> Add to Basket </button> </li></ul></div>" })
        .when("/basket", {controller : "basketController", controllerAs: 'bk', template: "<div><ul><li ng-repeat='product in bk.basket'>{{product.Name}} {{product.Quantity}} </ul> <p>Total: {{bk.total}}</p></div>" })
    }])

    .factory("apiService", ["$http", function ($http) {
        return {
            getProducts: function () {
                return $http.get("/api/product")
            },
            getBasketTotal: function (basketItems) {
                return $http.post('/api/basket/GetTotal', { products: basketItems });
            }
        }
    }]).
    factory("basketService", ["$q", "apiService", function ($q, apiService) {
        var basket = [];
        return {
            getBasket: function () {
                return $q(function (resolve) {
                    apiService.getBasketTotal(basket).then(function (result) {
                        resolve({
                            products: basket,
                            total: result.data.Total
                        })
                    })
                })
            },
            addProductToBasket: function (product) {
                for (var i = 0; i < basket.length; i++) {
                    if (basket[i].Id === product.Id) {
                        basket[i].Quantity++;
                        return;
                    }
                }

                basket.push(angular.extend({}, product, { ProductId: product.Id,  Quantity: 1 }));
            }
        }
    }]).
    controller("homeController", ["apiService", "basketService", function (apiService, basketService) {
        var vm = this;
        vm.products = [];

        apiService.getProducts().then(function (result) {
            vm.products = result.data.Products
        });

        vm.addToBasket = function (product) {
            basketService.addProductToBasket(product);
            alert('added');
        }
    }]).
    controller("basketController", ["basketService", function (basketService) {
        var vm = this;
        vm.basket = [];
        vm.total = 0;

        basketService.getBasket().then(function (result) {
            vm.basket = result.products;
            vm.total = result.total;
        });
    }])

})();