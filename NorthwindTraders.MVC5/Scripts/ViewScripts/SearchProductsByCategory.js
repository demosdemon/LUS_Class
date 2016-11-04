/* 
    SearchProductsByCategory.js
    Contains client side logic for SearchProductsByCategory.cshtml for the Product Controller
*/

// Jquery document ready event

$(function () {
    var vm = new SearchProductsViewModel();
    vm.readAllCategories();
    ko.applyBindings(vm);
});

var SearchProductsViewModel = function() {
    var self = this;

    self.categories = ko.observableArray([]);

    self.categoryID = ko.observable(0);

    self.products = ko.observableArray([]);

    self.errors = ko.observableArray([]);

    self.readAllCategories = function () {
        $.ajax({
            url: '/Data/ReadAllCategories',
            type: 'GET'
        }).done(function (categories) {
            self.categories(categories);
        }).fail(function (error) {
            self.errors.push(JSON.stringify(error, null, 2));
        });
    };

    self.readProductsByCategory = function (categoryID) {
        if (!categoryID) {
            self.products([]);
            return;
        }

        $.ajax({
            url: '/Data/ReadProductsByCategory/' + categoryID,
            type: 'GET'
        }).done(function (products) {
            self.products(products);
        }).fail(function (error) {
            self.errors.push(JSON.stringify(error, null, 2));
        });
    };

    self.categoryID.subscribe(function (categoryID) {
        self.readProductsByCategory(categoryID);
    });
}
