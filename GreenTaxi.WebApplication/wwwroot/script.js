const header = document.querySelector("header");
    window.addEventListener("scroll", function() {
        header.classList.toggle("sticky", window.scrollY > 100);
    });
let menu = document.querySelector('#menu-icon');
let navlinks = document.querySelector('.navlinks');

menu.onclick = () => {
    menu.classList.toggle("bx-x");
    navlinks.classList.toggle('open');
};

window.onscroll = () => {
    menu.classList.remove('bx-x');
    navlinks.classList.remove('open');
};
const animate = ScrollReveal({
    origin : 'top', 
    distance : '65px',
    duration : '2600',
    deplay : '400'
});
animate.reveal(".home-text,.about-img,.feature-left, .social-icons", { origin:"left"})

animate.reveal(".arrow,.about-text,.feature-right", { origin:"right"})

animate.reveal(".home-img,.text-center,.services-content,.feature-middle,.end-text1,.end-text2,.contact-box", { interval:150})

// Login 
document.getElementById('login').addEventListener('click', function() {
    window.location.href = 'login.html'; // Chuyển hướng đến trang login
});

