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
    // onclick
    $.get("/admin/History/Export_Excel", function (data) {
    });
}