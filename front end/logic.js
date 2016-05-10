var getStuff = function () {
    employeeArr = [];
    printedArr = [];
    $.getJSON('http://michaelmw7x990:3001/employees',
    function(err, data) {
        if (err != null) {
            alert("Something went wrong: " + err);
        } else {
            employeeArr = data.response.response.Table;
            forEach(employee in employeeArr)
            {
                printedArr = new employee()


            }
            return data;
        }
    });
}