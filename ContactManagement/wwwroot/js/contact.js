// Load Data in Table when document is ready
$(document).ready(function () {
    loadData();
});
// Load Data function
function getUsFormattedDate(date) {
    date = new Date(date);
    var year = date.getFullYear();

    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;

    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;

    return month + '/' + day + '/' + year;
}
function getFormattedDate(date) {
    date = new Date(date);
    var year = date.getFullYear();

    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;

    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;

    return year + '-' + month + '-' + day;
}
function loadData() { 
    $.ajax({
        url: "/Contacts/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var modifieddate = getUsFormattedDate(item.DateOfBirth);
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.EmailId + '</td>';
                html += '<td>' + item.SocialSecurityNumber + '</td>';
                html += '<td>' + modifieddate + '</td>';
                html += '<td>' + item.Gender + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function search() {
   
    //"/Contacts/getbyID/" + Id,
    $.ajax({
        url: "/Contacts/Search?searchtext=" + $('#Search').val(),
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var modifieddate = getUsFormattedDate(item.DateOfBirth);
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.EmailId + '</td>';
                html += '<td>' + item.SocialSecurityNumber + '</td>';
                html += '<td>' + modifieddate + '</td>';
                html += '<td>' + item.Gender + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// Add Data Function
function Add() {
 
    var res = validate();
    if (res == false) {
        return false;
    }
    var date = new Date($('#DateOfBirth').val());
    const formattedDate = date.toISOString().split('T')[0];

    var modifieddate = new Date(Date.now()).toLocaleString().split(',')[0];

    var contactDto = {

       // Id: $('#Id').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Gender: $('#Gender').val(),
        Address1: $('#Address1').val(),
        Address2: $('#Address2').val(),
        City: $('#City').val(),
        State: $('#State').val(),
        PinCode: $('#PinCode').val(),
        PhoneNumber: $('#PhoneNumber').val(),
        FaxNumber: $('#FaxNumber').val(),
        EmailId: $('#EmailId').val(),
        SocialSecurityNumber: $('#SocialSecurityNumber').val(),
        DateOfBirth: formattedDate,
        UserName: $('#UserName').val(),
        UserPassword: $('#UserPassword').val(),
        Modified_Date: modifieddate,
        IsActive: true
    };

    $.ajax({
        url: "/Contacts/Add",
        data: contactDto,
        type: "POST",
        //contentType: "application/json;charset=utf-8",
        //dataType: "json",
        success: function (result) {
         //   loadData();
            // $('#myModal').modal('hide');
            window.location.href = "/Contacts/Index";
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// Function for getting the Data Based upon Employee ID
function getbyID(Id) {
    $('#FirstName').css('border-color', 'lightgrey');
    $('#LastName').css('border-color', 'lightgrey');
    $('#EmailId').css('border-color', 'lightgrey');
    $('#SocialSecurityNumber').css('border-color', 'lightgrey');
    $('#PhoneNumber').css('border-color', 'lightgrey');
    $('#FaxNumber').css('border-color', 'lightgrey');
    $('#DateOfBirth').css('border-color', 'lightgrey');
    $('#UserName').css('border-color', 'lightgrey');
    $('#UserPassword').css('border-color', 'lightgrey');
    $('#Address1').css('border-color', 'lightgrey');
    $('#Address2').css('border-color', 'lightgrey');
    $('#City').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#PinCode').css('border-color', 'lightgrey');


    $.ajax({
        url: "/Contacts/getbyID/" + Id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

           // var modifieddate = new Date(result.DateOfBirth).toLocaleDateString('en-US');
            modifieddate = getFormattedDate(result.DateOfBirth);
           
           // modifieddate = "2010-01-01";
            
            console.log(modifieddate)
          
            $('#Id').val(result.Id);
            $('#FirstName').val(result.FirstName);
            $('#LastName').val(result.LastName);
            $('#EmailId').val(result.EmailId);
            $('#SocialSecurityNumber').val(result.SocialSecurityNumber);
            $('#Gender').val(result.Gender);
            
            $('#PhoneNumber').val(result.PhoneNumber);
            $('#FaxNumber').val(result.FaxNumber);
            $('#DateOfBirth').val(modifieddate);
            $('#UserName').val(result.UserName);
            $('#UserPassword').val(result.UserPassword);
            $('#Address1').val(result.Address1);
            $('#Address2').val(result.Address2);
            $('#UserPassword').val(result.UserPassword);
            $('#Address1').val(result.Address1);
            $('#Address2').val(result.Address2);

            $('#City').val(result.City);
            $('#State').val(result.State);
            $('#PinCode').val(result.PinCode);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function Close() {
    $('#myModal').modal('hide');
}
// Function for updating employee's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var date = new Date($('#DateOfBirth').val());
    const formattedDate = date.toISOString().split('T')[0];

    var modifieddate = new Date(Date.now()).toLocaleString().split(',')[0];

    var contactDto = {

        Id: $('#Id').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Gender: $('#Gender').val(),
        Address1: $('#Address1').val(),
        Address2: $('#Address2').val(),
        City: $('#City').val(),
        State: $('#State').val(),
        PinCode: $('#PinCode').val(),
        PhoneNumber: $('#PhoneNumber').val(),
        FaxNumber: $('#FaxNumber').val(),
        EmailId: $('#EmailId').val(),
        SocialSecurityNumber: $('#SocialSecurityNumber').val(), 
        DateOfBirth: formattedDate,
        UserName: $('#UserName').val(),
        UserPassword: $('#UserPassword').val(),
        Modified_Date: modifieddate,           
        IsActive: true
    };

   // console.log(contactDto);

    $.ajax({
        url: "/Contacts/Update",
        data: contactDto,
        //data: JSON.stringify(contactDto),
        type: "POST",
        //contentType: "application/json;charset=UTF-8",      
        //dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Id').val();
            $('#FirstName').val();
            $('#LastName').val();         
            $('#EmailId').val();
            $('#SocialSecurityNumber').val();
            $('#Gender').val();
            $('#PhoneNumber').val();
            $('#FaxNumber').val();
            $('#DateOfBirth').val();
            $('#UserName').val();
            $('#UserPassword').val();
            $('#Address1').val();
            $('#Address2').val();
            $('#UserPassword').val();
            $('#Address1').val();
            $('#Address2').val();
            $('#City').val();
            $('#State').val();
            $('#PinCode').val();
        },
        error: function (errormessage) {
            console.log(errormessage);
            alert(errormessage.responseText);
        }
    });
}

function validate() {
   return validateForm();
    //if ($('#FirstName').val() == '' || $('#LastName').val() == '' ||
    //    $('#EmailId').val() == '' || $('#SocialSecurityNumber').val() == '' || $('#Gender').val() == '' ||
    //    $('#PhoneNumber').val() == '' || $('#DateOfBirth').val() == '' || $('#UserName').val() == '' ||
    //    $('#UserPassword').val() == '') {
    //    alert('Please enter manadatory field(s)');
    //    return false;
    //}


   
}

function validateForm() {
    var isError = true;
    var nameReg = /^[A-Za-z]+$/;
    var numberReg = /^[0-9]+$/;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

    var FirstName = $('#FirstName').val();
    var LastName = $('#LastName').val();
    var EmailId = $('#EmailId').val();
    var SocialSecurityNumber = $('#SocialSecurityNumber').val();
    var PhoneNumber = $('#PhoneNumber').val();
    var DateOfBirth = $('#DateOfBirth').val();
    var UserName = $('#UserName').val();
    var UserPassword = $('#UserPassword').val();

    var inputVal = new Array(FirstName, LastName, EmailId, SocialSecurityNumber, PhoneNumber, DateOfBirth, UserName, UserPassword);

    var inputMessage = new Array("FirstName", "LastName", "EmailId", "SocialSecurityNumber", "PhoneNumber", "DateOfBirth", "UserName", "UserPassword");

    $('.error').hide();

    if (inputVal[0] == "") {
        $('#FirstName').after('<span class="error"> Please enter your ' + inputMessage[0] + '</span>');
        isError = false;
    }
    else if (!nameReg.test(FirstName)) {
        $('#FirstName').after('<span class="error"> Letters only</span>');
        isError = false;
    }

    if (inputVal[1] == "") {
        $('#LastName').after('<span class="error"> Please enter your ' + inputMessage[1] + '</span>');
        isError = false;
    }

    if (inputVal[2] == "") {
        $('#EmailId').after('<span class="error"> Please enter your ' + inputMessage[2] + '</span>');
        isError = false;
    }
    else if (!emailReg.test(EmailId)) {
        $('#EmailId').after('<span class="error"> Please enter a valid email address</span>');
        isError = false;
    }
    if (inputVal[3] == "") {
        $('#SocialSecurityNumber').after('<span class="error"> Please enter your ' + inputMessage[1] + '</span>');
        isError = false;
    }

    if (inputVal[4] == "") {
        $('#PhoneNumber').after('<span class="error"> Please enter your ' + inputMessage[4] + '</span>');
        isError = false;
    }
    else if (!numberReg.test(PhoneNumber)) {
        $('#PhoneNumber').after('<span class="error"> Numbers only</span>');
        isError = false;
    }

    if (inputVal[5] == "") {
        $('#DateOfBirth').after('<span class="error"> Please enter your ' + inputMessage[5] + '</span>');
        isError = false;
    }
    if (inputVal[6] == "") {
        $('#UserName').after('<span class="error"> Please enter your ' + inputMessage[6] + '</span>');
        isError = false;
    }
    if (inputVal[7] == "") {
        $('#UserPassword').after('<span class="error"> Please enter your ' + inputMessage[7] + '</span>');
        isError = false;
    }
    return isError;
}   


// Function for deleting employee's record
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Contacts/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

// Function for clearing the textboxes
function clearTextBox() {
    $('#EmployeeID').val("");
    $('#Name').val("");
    $('#Age').val("");
    $('#State').val("");
    $('#Country').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
}