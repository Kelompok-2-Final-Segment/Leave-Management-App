// Import
import Alert from "../utilities/alert.js";

/* Employee Data Table */
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
        {
            data: null,
            render: function (data, type, row, meta) {
                if (row.lastName == null) {
                    return row.firstName;
                }

                return row.firstName + " " + row.lastName;
            }        },
        { data: "gender" },
        { data: "roleName" },
        { data: "departmentName" },
        {
            data: null,
            render: function (data, type, row, meta) {
                const deleteButton = document.createElement('button');
                deleteButton.type = 'button';
                deleteButton.className = 'btn btn-danger';
                deleteButton.innerText = 'Delete';
                deleteButton.setAttribute('onclick', `deleteEmployee("${row.guid}")`);

                const form = document.createElement('form');
                form.method = 'post';
                form.action = '/admin/employee/detail';  // Ganti dengan path dan controller yang sesuai
                form.style.display = 'inline';

                const hiddenInput = document.createElement('input');
                hiddenInput.type = 'hidden';
                hiddenInput.name = 'guid';
                hiddenInput.value = row.guid;

                const detailButton = document.createElement('button');
                detailButton.type = 'submit';
                detailButton.className = 'btn btn-primary';
                detailButton.innerText = 'Detail';

                form.appendChild(hiddenInput);
                form.appendChild(detailButton);

                return `${deleteButton.outerHTML} ${form.outerHTML}`;
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
document.getElementById('create-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('excel-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('pdf-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('colvis-btn').classList.remove('dt-button');

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
    console.log(createAction);
    console.log(json);

    $.ajax({
        type: 'POST',
        url: createAction,
        data: { entity: json },
        dataType: "json",
    })
        .done((data, textStatus, errorThrown) => {
            $('#modal-create').modal('hide');
            console.log(data);
            if (data.code >= 300) {
                Swal.fire({
                    icon: 'error',
                    title: 'Failed to Create Employee Data',
                    text: 'Oops! Something went wrong while trying to create employee data. Please double-check your information.',
                    footer: '<a href="">Why do I have this issue?</a>'
                });
            }

            if (data.code >= 200 && data.code < 300) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Employee Data Created Successfully',
                    showConfirmButton: false,
                    timer: 2500
                });
            }

            $('#table-employee').DataTable().ajax.reload();
        });
});

/* Generate Department Option */
$.ajax({
    url: '/admin/department/all',
    method: 'GET'
})
    .done((data, textStatus, errorThrown) => {
        let result = data.data;

        for (let item of result) {
            $('#select-department').append(`<option value="${item.name}">${item.name}</option>`);
        }
    });

/* Clear Form Registration When Modal Show */
$('#modal-create').on('show.bs.modal', function () {
    $('#form-registration :input').val('');
    $('#select-gender').val($('#select-gender option:first').val());
    $('#select-role').val($('#select-role option:first').val());
    $('#select-department').val($('#select-department option:first').val());
});