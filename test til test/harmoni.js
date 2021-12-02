//change heading style
document.getElementById('small-display').textContent = "Opskrifter"

//change font style of heading
document.getElementsByTagName('h1')[0].style.fontFamily = "Impact,Charcoal,sans-serif"

//get the number of recipe boxes and replace the p id="total-num-recipes" inner text with this value
let cardBodyDivs = document.getElementsByClassName('card-body') 
document.getElementById('total-num-recipes').textContent = "You have  " + cardBodyDivs.length + " recipes so far"

//4 get all li tag and lowercase text inside
let LITags = document.querySelectorAll('li')
for (let i = 0; i < LITags.length; i++) {
  LITags[i].textContent = LITags[i].textContent.toLowerCase()
}