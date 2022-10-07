
let code = "";
let employeeid = "";
let employeename = "";
let experience = "";
let manager = "";
let wfmmanager = "";
let email = "";
$.get("GetEmployeesSkills", function (data, status) {
    for (let x in data) {
        employeeid = data[x].employee_id;
        employeename = data[x].employee_name;
        manager = data[x].manager;
        wfmmanager = data[x].wfm_manager;
        experience = data[x].experience;
        email = data[x].email;
        code += "<tr>"
        code += "<td>" + data[x].employee_id + "</td>"
        code += "<td align='left' style='padding: 10px 15px;'>" + data[x].employee_name + "</td>"
        code += "<td>"
        for (let y in data[x].skills)
            
            code += '<span style="float:left;background: lavender;border-color:black;color:darkolivegreen; width: 50px; padding: 3px; margin-left: 20px; list-style-type:none">' + data[x].skills[y] + "  "+'</span>'
        
        code += "</td>"
        code += "<td>" + data[x].experience + "</td>"
        code += "<td align='left' style='padding: 10px 15px;'>" + data[x].manager + "</td>"
        code += "<td>" + ('<button type="button" id="btnlock" onclick="requestLock(' + employeeid + ',\'' + employeename + '\',\'' + manager + '\',\'' + wfmmanager + '\',\'' + email + '\',' + experience + ')" style="width:200px;display: flex;flex-direction: column;align-items: center;padding: 6px 14px;font-family: -apple-system, BlinkMacSystemFont, sans-serif;border-radius: 6px;border: none;background: darkolivegreen;box-shadow: 0px 0.5px 1px rgba(0, 0, 0, 0.1), inset 0px 0.5px 0.5px rgba(255, 255, 255, 0.5), 0px 0px 0px 0.5px rgba(0, 0, 0, 0.12);color: #DFDEDF;user-select: none;-webkit-user-select: none;touch-action: manipulation;">Request lock</button>');
        code += "</td>"
        code += "</tr>"

    }
    $('#data').html(code)
})

function requestLock(empid, empname, manager, wfmmanager, email, empexp) {
    let modal = document.getElementById("myModal");
    modal.style.display = "block";
    document.getElementById("employeeId").innerHTML = empid;
    document.getElementById("empname").innerHTML = empname;
    document.getElementById("manager").innerHTML = manager;
    document.getElementById("wfm").innerHTML = wfmmanager;
    document.getElementById("email").innerHTML = email;
    document.getElementById("exp").innerHTML = empexp;
}

function closeClick() {
    let modal = document.getElementById("myModal");
    modal.style.display = "none";
}
 

function sendClick() {
    $.ajax({
        url: 'Softlock/Lockrequest',
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify({
            employeeId: $('#employeeId').text(),
            manager: $('#manager').text(),
            lockId: $('#employeeId').text(),
            requestmessage: $('#reqmsg').val(),
            status: "waiting",
            managerstatus: "awaiting_confirmation",
            wfmremark: $('#requestee').text()
        }),
        processData: false,
        success: function (data) {
            alert("Softlock Requested Successfully...")
            closeClick();
        },
        error: function () {
            alert("Something went wrong")
        }
    });

}