/* Employee Data Table */
$("#table-leave-type").DataTable({
    ajax: {
        url: 'https://localhost:7054/admin/leave/all',
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
        { data: "name" },
        { data: "balance" },
        { data: "minDuration" },
        { data: "maxDuration" },
        { data: "femaleOnly" },
        { data: null },
        {
            data: null,
            render: function (data, type, row, meta) {
                const deleteButton = document.createElement('button');
                deleteButton.type = 'button';
                deleteButton.className = 'btn btn-danger';
                deleteButton.innerText = 'Delete';
                deleteButton.setAttribute('onclick', `deleteLeaveType("${row.guid}")`);

                const detailButton = document.createElement('button');
                detailButton.type = 'submit';
                detailButton.className = 'btn btn-primary';
                detailButton.innerText = 'Edit';

                return `${detailButton.outerHTML} ${deleteButton.outerHTML}`;
            }
        },

    ];
}

// Export configuration for data table
function buttonConfig() {
    return [
        {
            text: 'Create Type',
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