// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var dataTable;
$(document).ready(function () {
    dataTable = $("#contact").DataTable({
        paging: true,
        responsive: true,
        lengthMenu: [5, 10, 15],
        ajax: {
            url: "/api/contact",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            }
        },
        "columns": [
            {
                "data": "name",
                "render": function (data, type, row) {
                    return `
                            <ul class="list-unstyled">
                              <li>${row.name}</li>
                              <li><small>${row.jobTitle}</small></li>
                            </ul>
                            `
                }
            },
            { "data": "company.name" },
            { "data": "phone" },
            { "data": "address" },
            { "data": "email" },
            {
                "data": "lastDateContacted",
                "render": function (data) {
                    return moment(data).format('MMM-YY-DD');
                }
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/contact/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    Edit
                                </a>
                                <a onclick="Delete('/api/contact/${data}')" data-id='${data}' class="btn btn-danger text-white" style="cursor:pointer">
                                    Remove
                                </a>
                            </div>
                            `
                }
            }
        ],
        columnDefs: [
            //add below class to TH whatever the columns no-search or no-sort
            { targets: "no-sort", orderable: false },
            { targets: "no-search", searchable: false },
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 }
        ]
    });
});

function Delete(url) {
    /* $('#Confirmation .modal-body p').text("Are you sure, you want to remove?");*/
    $('#Confirmation').modal('show');
    //delete confirmation for request successfully
    $('#Confirmation .btn-primary').unbind().click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "DELETE",
            url: url,
            success: function (data) {
                toastr.success(data.message, { fadeAway: 50000 });
                dataTable.ajax.reload();
                $('#Confirmation').modal('hide');
            },
            error: function (xhr, status, errorThrown) {
                toastr.error(xhr.responseText)
            }
        });
    });
}