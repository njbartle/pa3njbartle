let driver = [];
const baseUrl = "https://localhost:7081";
const body = docutment.getElementId('root');
let table = document.createElement('table');
table.className = 'table';
let thead = documnet.createElement('thead');
table.appendChild(thead);

function handleOnLoad()
{
    createDriverTable();
}

function createDriverTable()
{
    fetch(baseUrl).then(function(response)
    {
        console.log(response);
        return response.json;
    }).then(function(json)
    {
        console.log(json);
        driver = json;
        createHeader();
        createBody();
    });
}

function createHeader()
{
    let tr = document.createElement('tr');
    let array = ['EmployeeID', 'Employee Name', 'Employee Rating', 'Date Hired', 'Deleted Drivers'];
    array.forEach((heading)=>
    {
        let th = document.createElement('th');
        th.appendChild(document.createTextNode(heading));
        tr.appendChild(th);
    })
    thead.appendChild(tr);
    body.appendChild(table);    
}

function createBody()
{
    drivers.forEach(driver)
    {
        let tr = document.createElement('tr');
        let employeeIDTd = document.createElement('td');
        employeeIDTd.appendChild(document.createTextNode(driver.employeeID));
        tr.appendChild(employeeIDTd);
        
        let employeeNameTd = document.createElement('td');
        employeeNameTd.appendChild(document.createTextNode(driver.employeeName));
        tr.appendChild(employeeNameTd);

        let employeeRatingTd = document.createElement('td');
        employeeRatingTd.appendChild(document.createTextNode(driver.employeeRating));
        tr.appendChild(employeeRatingTd);

        let dateHiredTd = document.createElement('td');
        dateHiredTd.appendChild(document.createTextNode(driver.dateHired));
        tr.appendChild(dateHiredTd);

        let deletedDriverTd = document.createElement('td');
        deletedDriverTd.appendChild(document.createTextNode(driver.deletedDriver));
        tr.appendChild(deletedDriverTd);
    }
}