function tranToPageCatogoryManage() {
    $.get("/admin/category/index", function (data) {
        $("#content-admin").children().remove();
        $("#content-admin").append(data);
    });
}

function TranToPageUpdateCategory(id) {
    console.log(id)
}

function DeleteCategory(id) {
    console.log(id)
    var url = "https://localhost:44308/delete-category/"+id;
    $.ajax({
        url: url,
        contentType: "application/json",
        dataType: "json",
        type: "post",
        success: function (result) {
            if (result === true) {
                alert('xóa thành công');
                tranToPageCatogoryManage();
                return;
            }
            alert('Danh mục này không thể xóa');
            return;
        },
        error: function (msg) {
            alert('Thao tác thất bại');
        }
    });
}

function addCategory() {
    var categoryInput = prompt("Nhập Thể Loại Mới:");
    if (categoryInput != null && categoryInput != '') {
        $.post("/admin/category/AddCategory",
            { "categoryName": categoryInput },
            function (data) {
                $("#content-admin").children().remove();
                $("#content-admin").append(data);
                loadNumOfPageProduct();
            });
        console.log('vo nek')

    }
}


function tranToPageHistoryManager() {
    $.get("/admin/History/index", function (data) {
        $("#content-admin").children().remove();
        $("#content-admin").append(data);
    });
}

function exportExcel() {
    $.get("/admin/History/Export_Excel", function (data) {
    });
}