$('.edit-link').click(function (e) {
    var a_href = $(this).attr('href');
    e.preventDefault();
    $.ajax({
        url: a_href,
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        data: {
            'ID': ID,
            'accountName': accountName,
            'password': password,
            'fullName': fullName,
            'imagePath': imagePath,
            'birthDay': birthDay,
            'phone': phone,
            'email': email,
            'address': address,
            'createDate': createDate,
            'lastLogin': lastLogin,
            'accountGroupID': accountGroupID,
            'active': active
},
        success: function (data) {
            $('.body-content').prepend(data);
            $().val(data.id);
            $('#editModal').modal('show');
        }
    });
});