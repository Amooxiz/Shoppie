// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



const currButton = document.getElementById('currency');
const currencies = document.querySelectorAll('#curr');
console.log(currencies);

const changeVisiblity = (value) => {
    currencies.forEach((curr) => {
        if (curr.style.display === "none") {
            curr.style.display = 'block';
        }
        else {
            curr.style.display = 'none';
        }
    })
}
currButton.addEventListener('click', changeVisiblity);