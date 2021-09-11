$(document).ready(function () {
    loadData();
    /*   loadDataProduct(1);*/

})
function loadData() {
    $.ajax({
        url: "https://localhost:44308/get-list-user",
        method: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function () {
        }, fail: function () {
        }
    }).done(function (response) {
        $('.data-user tbody').empty();
        $.each(response, function (index, item) {
            var trhtml = $(`<tr>    
                <td style="text-align: center;">` + item.fullname + `</td>
                <td style="text-align: center;">`+ item.email + `</td>
                <td style="text-align: center;">`+ item.createAt + `</td>
                <td style="text-align: center;">`+ item.modifyAt + `</td>
                <td style="text-align: center;">
                    <a href="#" class="btn btn-danger btn_remove_item remove-user" data-id="#"><i class="ni ni-basket" onclick = "DeleteUser('`+ item.id + `')"></i></a>
                    <a href="#"class="btn btn-primary"><i class="ni ni-ruler-pencil" ></i></a>
                   
                </td>`);
            $('.data-user tbody').append(trhtml);
        })
    }).fail(function (response) {
    })
}

function loadNumOfPageProduct() {
    var url = "https://localhost:44308/numpageProduct"
    $.ajax({
        url: url,
        method: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function () {
        }, fail: function () {
        }
    }).done(function (response) {
        $('#paginationProductId').empty();
        for (let i = 1; i <= response; i++) {
            var trhtml = $(`
                         <li class="page-item"><a class="page-link" href="#" onclick = "transToPageListProduct(`+ i + `)">` + i + `</a></li>
                           `);
            $('#paginationProductId').append(trhtml);
        }
    }).fail(function (response) {
        alert('fail load numpage')
    })
}

function DeleteUser(id) {
    var url = "https://localhost:44308/delete-user/" + id;
    $.ajax({
        url: url,
        contentType: "application/json",
        dataType: "json",
        type: "Post",
        success: function (result) {
            if (result === true) {
                alert('xóa tài khoản thành công');
                loadData();
                return;
            }
            alert('tài khoản này không thể xóa');
            return;
        },
        error: function (msg) {
            alert('tài khoan khong thể xóa ');
        }
    });
}