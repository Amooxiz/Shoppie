// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const keyValues = window.location.search;

const urlParams = new URLSearchParams(keyValues);
const pageNr = urlParams?.get('pageNr');

const paginationLink = document.getElementsByClassName('custom-page-link')

const a = document.querySelector(`a[data-index="${pageNr ?? 1}"]`);

StyleLink(a);

function StyleLink(a) {
    a.style.border = '1px solid black';
    a.style.borderRadius = '50%';
}