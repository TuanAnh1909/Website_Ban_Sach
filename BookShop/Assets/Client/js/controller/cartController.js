$(function () {
    $(".btnDelete").off('click').on('click', function (e) {
        e.preventDefault();
        $.ajax({
            data: { id: $(this).data('id') },
            url: "/Cart/Delete",
            dataType: "json",
            type: "POST",
            success: function (res) {
                if (res.status == true) {
                    window.location.href = '/Cart/Index';
                }
            }

        });

    });

    $("#deleteall").off('click').on('click', function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Cart/DeleteAll",
            dataType: "json",
            type: "POST",

            success: function (res) {
                if (res.status == true) {
                    window.location.href = '/Cart/Index';
                }
            }

        });

    });


    $("#updateitem").off('click').on('click', function (e) {
        e.preventDefault();
        var sachlist = $('.txtquantity');//lấy ra các sách có class = soluongsach(nó sẽ là 1 danh sách)
        var cardlist = [];

        $.each(sachlist, function (i, item) {
            cardlist.push({
                Quantity: $(item).val(),
                Book: {
                    ID: $(item).data('id')
                }
            });//cartlist thêm vào 1 đối tượng có thuộc tính soluong và sách
        });

        $.ajax({
            url: "/Cart/Update",
            data: { cartModel: JSON.stringify(cardlist) },//dùng stringify để phân tích đối tượng json thành chuỗi gửi về controller
            dataType: "json",
            type: "POST",
            success: function (res) {
                if (res.status == true) {
                    window.location.href = '/Cart/Index';
                }
            }

        });

    });
});