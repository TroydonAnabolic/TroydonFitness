// Toggle search bar
$(document).ready(function () {
    $(".fa-search").mouseenter(function () {
        $(".search-input").toggleClass("hidden");
    });
    $(".search-input").mouseleave(function () {
        $(".search-input").toggleClass("hidden");
    });
    // reveals a create order dialog for all order types
    $(".order-button").click(function () {
        $(".create-order").removeClass("hidden");
    })
    $(".cancel-create").click(function () {
        $(".create-order").addClass("hidden");
    });

    // toggle between hidding and showing the nav to admin tasks
    $('#administration-nav').click(function () {
        $('.dropdown-content').toggleClass('hidden');
    });

    // redirect if user tries to order more than a quantity of 1 for training routine or diet
    if ($("#CartVM_Quantity").val() != "1") {
      //  alert("You can only place one order of this type");
    }

    // redirect to login
    $(".not-auth").click(function (e) {
        e.preventDefault();
        document.location = "/Identity/Account/Login";
    });

    // Begin Slide show animation
    var slideIndex = 0;
    var slideIndex2 = 0;
    showSlides();
    showSlides2();

    function showSlides() {
        var i;
        var slides = document.getElementsByClassName("mySlides");
        var dots = document.getElementsByClassName("dot");
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        slideIndex++;
        if (slideIndex > slides.length) { slideIndex = 1 }
        for (i = 0; i < dots.length; i++) {
            dots[i].className = dots[i].className.replace(" active", "");
        }
        slides[slideIndex - 1].style.display = "block";
        dots[slideIndex - 1].className += " active";
        setTimeout(showSlides, 2000); // Change image every 2 seconds
    }

    function showSlides2() {
        var i;
        var slides = document.getElementsByClassName("mySlides2");
        var dots = document.getElementsByClassName("dot2");
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        slideIndex2++;
        if (slideIndex2 > slides.length) { slideIndex2 = 1 }
        for (i = 0; i < dots.length; i++) {
            dots[i].className = dots[i].className.replace(" active", "");
        }
        slides[slideIndex2 - 1].style.display = "block";
        dots[slideIndex2 - 1].className += " active";
        setTimeout(showSlides2, 2000); // Change image every 2 seconds
    }
});

// Get the modal
var modal = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function () {
    modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}




// function closeNav() {
//     document.getElementById("mySidebar").style.width = "0";
//     document.getElementById("mainNav").style.marginLeft = "0";
// }

// Animated Hamburger Bar

