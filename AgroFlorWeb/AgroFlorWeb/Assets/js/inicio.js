var btn_user = document.getElementById('userbtn'),
    options_user = document.getElementById('useroptions'),
    menu_options = document.getElementById('usermenu'),
    control = 1;

btn_user.addEventListener('click', function () {
    if (control == 1) {
        options_user.classList.add('active');
        menu_options.classList.add('active');
        control++;
    } else {
        options_user.classList.remove('active');
        menu_options.classList.remove('active');
        control = 1;
    }
}); 