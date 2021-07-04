$(document).ready(function () {
    loadData();
})
function loadData() {
    $.ajax({
        url: "https://localhost:44308/get-list-user",
        method: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function () {
           /// debugger;
        }, fail: function () {
           // debugger;
        }
    }).done(function (response) {
        // debugger;
        $('.data-user tbody').empty();
        $.each(response, function (index, item) {
            var trhtml = $(`<tr>
                <td style="text-align: center;">` + item.id + `</td>
                <td style="text-align: center;">`+ item.Fullnname + `</td>
                <td style="text-align: center;">`+ item.Username + `</td>
                <td style="text-align: center;">`+ item.Password + `</td>
                <td style="text-align: center;">`+ item.Adress + `</td>
                <td style="text-align: center;">`+ item.Email + `</td>
                <td style="text-align: center;">
                    <a href="#" class="btn btn-danger btn_remove_item" data-id="#"><i class="ni ni-basket"></i></a>
                    <a href="/admin/updateProduct" class="btn btn-primary"><i class="ni ni-ruler-pencil"></i></a>
                </td>`);
            $('.data-user tbody').append(trhtml);
        })
    }).fail(function (response) {
        debugger;
    })


}