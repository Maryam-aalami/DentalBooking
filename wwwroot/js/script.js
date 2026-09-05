const bookBtn = document.getElementById("bookappointmentbtn");
const modal = document.getElementById("appointmentmodal");
const overlay = document.getElementById("modaloverlay");


bookBtn.addEventListener("click", function () {
    modal.style.display = "block";
    overlay.style.display = "block"
});