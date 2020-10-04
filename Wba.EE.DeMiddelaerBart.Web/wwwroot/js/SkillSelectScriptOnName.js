var indexListOfPokemons = [];
var PreSelectidNames = document.querySelectorAll('#preSelection');
var hiddenInputForSelectidCards = document.getElementById('cardsPasser').querySelectorAll('#selectidCard');


for (let i = 0; i < countOfCards; i++) {

    document.getElementById(`skillsCard${i}`).addEventListener('click', () => {

        if (document.getElementById(`skillsCard${i}`).style.borderColor == selectColorOne ||
            document.getElementById(`skillsCard${i}`).style.borderColor == selectColorTwo) {
            //----------------------------------------------------------------------------
            document.getElementById(`skillsCard${i}`).style.borderColor = 'rgb(222, 233, 80)';

            //----------------------------------------------------------------------------
        } else {
            //----------------------------------------------------------------------------
            if (indexListOfPokemons.length != maxSelectebelPokemons) {
                document.getElementById(`skillsCard${i}`).style.borderColor = flickerSelectColor;
            }

            //----------------------------------------------------------------------------
        }
    })
}
window.setInterval(() => {

    indexListOfPokemons = [];

    for (let c = 0; c < countOfCards; c++) {

        flickerSelectColor = flickerSelectColor == selectColorOne
            ? selectColorTwo
            : selectColorOne;

        if (document.getElementById(`skillsCard${c}`).style.borderColor == selectColorOne ||
            document.getElementById(`skillsCard${c}`).style.borderColor == selectColorTwo) {
            //----------------------------------------------------------------------------
            document.getElementById(`skillsCard${c}`).style.borderColor = flickerSelectColor;
            let pokemonName = document.getElementById(`skillsCard${c}`).querySelector('#skillsCardName').innerText;

            //----------------------------------------------------------------------------
            indexListOfPokemons.push(pokemonName);
        }
    }

    for (let a = 0; a < maxSelectebelPokemons; a++) {


        if (indexListOfPokemons[a] != null)
            hiddenInputForSelectidCards[a].value = indexListOfPokemons[a];
        else
            hiddenInputForSelectidCards[a].value = '';
    }

}, 100);