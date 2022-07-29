function convertFormToJSON(form) {
    const array = $(form).serializeArray(); // Encodes the set of form elements as an array of names and values.
    const json = {};
    $.each(array, function () {
        json[this.name] = this.value || "";
    });
    return json;
}
function Confirmation() {
    var validator = $("#contact").validate();
    var isValid = validator.form();
    if (isValid) {
        $('#Confirmation .modal-body p').text("Are you sure, you want to save?");
        $('#Confirmation').modal('show');
        $('#Confirmation .btn-primary').on('click', function (e) {
            e.preventDefault();
            var data = convertFormToJSON($("#contact"));
            $.ajax({
                type: "POST",
                url: "../api/contact",
                contentType: "application/json",
                data: JSON.stringify(data),
                success: function (data) {
                    toastr.success(data.message);
                    window.location.href = "/";
                },
                error: function (xhr, status, errorThrown) {
                    toastr.error(xhr.responseText)
                }
            });
        });
    }
}

$(function () {
    $('#LastDateContacted').mask('00/00/0000');
    $('#Phone').mask('000-000-0000');
    $('#LastDateContacted').datepicker({
        changeMonth: true,
        changeYear: true,
        format: "mm/dd/yyyy",
        language: "tr"
    });
});
