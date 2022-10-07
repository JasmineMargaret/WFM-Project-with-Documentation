
let code = "";
let status = "";
let mgrstatus="";
let msg="";
$.get("softlock/GetLocks", function (data, status) {

    for (let x in data) {
        code += "<tr>"
        code += "<td>" + data[x].employeeId + "</td>"
        code += "<td align='left' style='padding-left:40px;'>" + data[x].wfmremark + "</td>"
        code += "<td>" + data[x].reqdate.substring(0, 10) + "</td>"
        code += "<td align='left' style='padding-left:50px;'>" + data[x].manager + "</td>"
        code += "<td>" + ('<button type="button" id="btnlock" onclick="viewLock(' + data[x].id + ',' + data[x].employeeId + ',\'' + data[x].wfmremark + '\',\'' + data[x].manager + '\',\'' + data[x].requestmessage + '\',\'' + data[x].reqdate + '\',\'' + data[x].mgrlastupdate + '\' )" style="width:200px;display: flex;flex-direction: column;align-items: center;padding: 6px 14px;font-family: -apple-system, BlinkMacSystemFont, sans-serif;border-radius: 6px;border: none;background: darkolivegreen;box-shadow: 0px 0.5px 1px rgba(0, 0, 0, 0.1), inset 0px 0.5px 0.5px rgba(255, 255, 255, 0.5), 0px 0px 0px 0.5px rgba(0, 0, 0, 0.12);color: #DFDEDF;user-select: none;-webkit-user-select: none;touch-action: manipulation;">View Details</button>');
        code += "</td>"
        code += "</tr>"
    }
    $('#data').html(code)
})

function viewLock(id,empid, requestee, manager, reqmsg,reqdate,mgrdate ) {
    let modal = document.getElementById("myModal");
    modal.style.display = "block";
    document.getElementById("id").innerHTML = id;
    document.getElementById("employeeId").innerHTML = empid;
    document.getElementById("requestee").innerHTML = requestee;
    document.getElementById("manager").innerHTML = manager;
    document.getElementById("reqmsg").innerHTML = reqmsg;
    document.getElementById("reqdate").innerHTML = reqdate;
    document.getElementById("mgrdate").innerHTML = mgrdate; 
}

function closeClick() {
    let modal = document.getElementById("myModal");
    modal.style.display = "none";
}



function approveClick() {
    if ($("#ddlstatus").val() == "approve") {
        status = "approved,locked";
        mgrstatus = "accepted";
        msg = "Approved Successfully...!!!";
    }
    else if ($("#ddlstatus").val() == "reject") {
        status = "rejected,not_requested";
        mgrstatus = "rejected";
        msg = "Rejected Successfully...!!!";
    }
    $.ajax({
        url: 'Softlock/Approverequest',
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify({
            id:$("#id").text(),
            employeeId: $('#employeeId').text(),
            manager: $('#manager').text(),
            lockId: $('#employeeId').text(),
            requestmessage: $('#reqmsg').text(),
            status: status,
            managerstatus: mgrstatus,
            wfmremark: $('#requestee').text(),
            reqdate: $('#reqdate').text(),
            mgrlastupdate: $('#mgrdate').text()
        }),
        processData: false,
        success: function (data) {
            alert(msg)
            closeClick();
        },
        error: function () {
            alert("Something went wrong")
        }
    });

}