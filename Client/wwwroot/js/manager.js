﻿// Main
setDataTable();
console.log("Hellow");

// Data Table
function setDataTable() {
    $("#table-employee").DataTable({
        ajax: {
            url: 'https://localhost:7007/api/Employee',
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
            data: "guid",
            render: function (data, type, row, meta) {
                return meta.row + meta.settings._iDisplayStart + 1;
            }
        },
        { data: "nik" },
        {
            data: "fullName",
            render: function (data, type, row, meta) {
                return row.firstName + ' ' + row.lastName;
            }
        },
        { data: "gender" },
        {
            data: "birthDate",
            render: function (data, type, row, meta) {
                return shortDateTime(data);
            }
        },
        {
            data: "hiringDate",
            render: function (data, type, row, meta) {
                return shortDateTime(data);
            }
        },
        { data: "email" },
        { data: "phoneNumber" },
        {
            data: null,
            render: function (data, type, row, meta) {
                const deleteButton = document.createElement('button');
                deleteButton.type = 'button';
                deleteButton.className = 'btn btn-danger btn-delete-employee';
                deleteButton.innerText = 'Delete';

                document.addEventListener('DOMContentLoaded', function () {
                    deleteButton.addEventListener('click', function () {
                        console.log(row.guid);
                    });
                });

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
    $('#create-btn, #excel-btn, #pdf-btn').removeClass('dt-button buttons-pdf buttons-html5');
    $('#colvis-btn').removeClass('dt-button');
    console.log("hellow");
}