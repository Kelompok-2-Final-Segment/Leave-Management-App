$(document).ready(function () {
    // Initialize DataTable for the leaves table with Buttons and ColVis
    var leavesTable = $('#tableLeaves').DataTable({
        ajax: {
            url: "https://localhost:7064/api/Leaves/",
            dataSrc: "data",
            dataType: "JSON"
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + 1;
                }
            },
            { data: "startDate" },
            { data: "endDate" },
            { data: "description" },
            { data: "status" },
            {
                data: null,
                render: function (data, type, row) {
                    return `<div class="btn-group" role="group" style="margin-right: 10px;">
                                <button type="button" class="btn btn-primary btn-sm" onclick="cancelLeave('${row.guid}')">Detail</button>
                            </div>`;
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excel',
                text: 'Excel',
                className: 'btn btn-success btn-sm',
                exportOptions: {
                    columns: ':visible:not(:last-child)'
                },
                init: function (dt, node, config) {
                    $(node).removeClass('dt-button buttons-excel button-html5');
                }
            },
            {
                extend: 'pdfHtml5',
                text: 'PDF',
                className: 'btn btn-danger btn-sm',
                exportOptions: {
                    columns: ':visible:not(:last-child)'
                },
                init: function (dt, node, config) {
                    $(node).removeClass('dt-button buttons-pdf button-html5');
                }
            },
            {
                extend: 'colvis',
                text: 'Column visibility',
                className: 'btn btn-secondary',
                init: function (dt, node, config) {
                    $(node).removeClass('dt-button buttons-collection button-colvis');
                }
            }
        ]
    });
});


