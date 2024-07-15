$(document).ready(funtion(){
    loadDataTable();
}

);

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {url: '/admin/product/getall'},
       columns: [
           { data: 'name' ,"width":"15%"},
           { data: 'position', "width": "15%" },
           { data: 'salary', "width": "15%" },
           { data: 'state_date', "width": "15%" },
           { data: 'office', "width": "15%" },
           { data: 'extn', "width": "15%" }
       ]
    });
}


