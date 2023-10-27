// Import
import Alert from "../utilities/alert.js";

// Main
dataTable();
console.log("Hellow");

/* Data Table for Getting Employees Data */
// Data Table
function dataTable() {
    $("#table-employee").DataTable({
        ajax: {
            url: 'https://localhost:7054/admin/employee/all',
            dataSrc: 'data',
            dataType: 'JSON'
        },
        columns: columnConfig(),
        dom: 'Bfrtip',
        buttons: buttonConfig()
    });

    setBootstrapToDataTableButton()
}

// Create column configuration for data table
function columnConfig() {
    return [
        {
            data: null,
            render: function (data, type, row, meta) {
                return meta.row + meta.settings._iDisplayStart + 1;
            }
        },
        { data: "nik" },
        { data: "fullName" },
        { data: "gender" },
        { data: "roleName" },
        { data: "departmentName" },
        {
            data: null,
            render: function (data, type, row, meta) {
                const deleteButton = document.createElement('button');
                deleteButton.type = 'button';
                deleteButton.className = 'btn btn-danger btn-delete-employee';
                deleteButton.innerText = 'Delete';
                deleteButton.setAttribute('onclick', `deleteEmployee("12345")`);

                return deleteButton.outerHTML;
            }
        },

    ];
}

// Export configuration for data table
function buttonConfig() {
    return [
        {
            text: 'Create Employee',
            attr: {
                title: 'Copy',
                id: 'create-btn',
                'data-bs-toggle': 'modal',
                'data-bs-target': '#modal-create'
            },
            className: 'btn btn-primary',
            action: function (e, dt, node, config) {

            }
        },
        {
            extend: 'excelHtml5',
            attr: {
                title: 'Save as Excel',
                id: 'excel-btn'
            },
            className: 'btn btn-success',
            exportOptions: {
                columns: ':visible:not(:last-child)'
            }
        },
        {
            extend: 'pdfHtml5',
            attr: {
                title: 'Save as PDF',
                id: 'pdf-btn'
            },
            className: 'btn btn-danger',
            exportOptions: {
                columns: ':visible:not(:last-child)'
            }
        },
        {
            extend: 'colvis',
            attr: {
                title: 'Select Column',
                id: 'colvis-btn'
            },
            className: 'btn btn-secondary'
        }
    ];
}

// Remove data table default class for avoiding conflict with bootstrap styles
function setBootstrapToDataTableButton() {
    document.getElementById('create-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
    document.getElementById('excel-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
    document.getElementById('pdf-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
    document.getElementById('colvis-btn').classList.remove('dt-button');
    console.log("testing");
}

// Delete Employee
function deleteEmployee(guid) {
    console.log("Hellow");
}

/* AJAX For Register*/
$('#button-register').on('click', () => {
    var registrationData = {
        firstName: $('#input-firstname').val(),
        lastName: $('#input-lastname').val(),
        birthDate: $('#input-birthdate').val(),
        hiringDate: $('#input-hiring-date').val(),
        gender: parseInt($('#select-gender').val(), 10),
        email: $('#input-email').val(),
        phoneNumber: $('#input-phone-number').val(),
        roleName: $('#select-role').val(),
        departmentName: $('#select-department').val(),
        password: $('#input-password').val(),
        confirmPassword: $('#input-confirm-password').val()
    }

    let json = JSON.stringify(registrationData);
    console.log(aspAction);
    console.log(json);

    $.ajax({
        type: 'POST',
        url: aspAction,
        data: { entity: json },
        dataType: "json",
    })
        .done((data, textStatus, errorThrown) => {
            $('#modal-create').modal('hide');
            console.log(data);
            if (data.code >= 300) {
                console.log("Error bang");
                Alert.error();
            }

            if (data.code >= 200 && data.code < 300) {
                console.log("Sukses bang");
                Alert.success("Employee Data Created Successfully!");
            }

            $('#table-employee').DataTable().ajax.reload();
        });
});
