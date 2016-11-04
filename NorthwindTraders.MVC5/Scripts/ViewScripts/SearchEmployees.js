/* 
    SearchEmployees.js
    Contains client side logic for SearchEmployees.cshtml for the EmployeeController
*/

// Jquery document ready event
$(function () {
    var vm = new SearchEmployeeViewModel();

    ko.applyBindings(vm);

    

    vm.readEmployeeCount();
    vm.readDistinctTitles();
});

function SearchEmployeeViewModel() {
    self = this;

    this.employeeCount = ko.observable(0);

    this.employeeTitles = ko.observable([]);

    this.selectedTitle = ko.observable();

    this.selectedEmployees = ko.observable([]);

    this.errors = ko.observableArray([]);

    this.readEmployeeCount = function () {
        $.ajax({
            url: '/Data/ReadEmployeeCount',
            type: 'GET'
        }).done(function (employeeCount) {
            self.employeeCount(employeeCount);
        }).fail(function (error) {
            self.errors.push(JSON.stringify(error, null, 2));
        });
    };

    this.readDistinctTitles = function () {
        $.ajax({
            url: '/Data/ReadDistinctTitles',
            type: 'GET'
        }).done(function (titles) {
            self.employeeTitles(titles);
        }).fail(function (error) {
            self.errors.push(JSON.stringify(error, null, 2));
        });
    };

    this.readEmployeesByTitle = function (title) {
        if (!title) {
            self.selectedEmployees([]);
            return;
        }

        $.ajax({
            url: '/Data/ReadEmployeesByTitle/' + encodeURIComponent(title),
            type: 'GET'
        }).done(function (selectedEmployees) {
            self.selectedEmployees(selectedEmployees);
        }).fail(function (error) {
            self.errors.push(JSON.stringify(error, null, 2));
        });
    };

    self.selectedTitle.subscribe(function (title) {
        self.readEmployeesByTitle(title);
    });

    self.selectedEmployees.subscribe(function (selectedEmployees) {
        if (selectedEmployees.length) {
            self.employeeCount(selectedEmployees.length);
        } else {
            self.readEmployeeCount();
        }
    });
}
