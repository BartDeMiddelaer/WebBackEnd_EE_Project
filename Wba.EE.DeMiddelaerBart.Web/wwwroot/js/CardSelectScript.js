var indexListOfPokemons = [];
var PreSelectidNames = document.querySelectorAll('#preSelection');
var hiddenInputForSelectidCards = document.getElementById('cardsPasser').querySelectorAll('#selectidCard');

// duit kaarten aan die in Resources.STon.ActivePlayersDeck zitten

if (PreSelectidNames.length != 0) {
    for (let p = 0; p < countOfCards; p++) {

        let nameA = document.getElementById(`card${p}`).querySelector('#pokemonName').innerText;

        for (let k = 0; k < PreSelectidNames.length; k++) {

            let nameB = PreSelectidNames[k].value

            if (nameA == nameB) {
                indexListOfPokemons.push(p);
                document.getElementById(`card${p}`).style.borderColor = flickerSelectColor;
                document.getElementById(`card${p}`).querySelector('#pokemonImg').style.backgroundColor = flickerSelectColor;
                document.getElementById(`card${p}`).querySelector('#alleSkillsOfType').style.backgroundColor = flickerSelectColor;
            }
        }
    }
}

for (let i = 0; i < countOfCards; i++) {

    document.getElementById(`card${i}`).addEventListener('click', () => {

        if (document.getElementById(`card${i}`).style.borderColor == selectColorOne ||
            document.getElementById(`card${i}`).style.borderColor == selectColorTwo) {
            //----------------------------------------------------------------------------
            document.getElementById(`card${i}`).style.borderColor = 'rgb(222, 233, 80)';
            document.getElementById(`card${i}`).querySelector('#pokemonImg').style.backgroundColor = 'lavender';
            document.getElementById(`card${i}`).querySelector('#alleSkillsOfType').style.backgroundColor = 'lavender';

            //----------------------------------------------------------------------------
        } else {
            //----------------------------------------------------------------------------
            if (indexListOfPokemons.length != maxSelectebelPokemons) {
                document.getElementById(`card${i}`).style.borderColor = flickerSelectColor;
                document.getElementById(`card${i}`).querySelector('#pokemonImg').style.backgroundColor = flickerSelectColor;
                document.getElementById(`card${i}`).querySelector('#alleSkillsOfType').style.backgroundColor = flickerSelectColor;
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

        if (document.getElementById(`card${c}`).style.borderColor == selectColorOne ||
            document.getElementById(`card${c}`).style.borderColor == selectColorTwo) {
            //----------------------------------------------------------------------------
            document.getElementById(`card${c}`).style.borderColor = flickerSelectColor;
            document.getElementById(`card${c}`).querySelector('#pokemonImg').style.backgroundColor = flickerSelectColor;
            document.getElementById(`card${c}`).querySelector('#alleSkillsOfType').style.backgroundColor = flickerSelectColor;

            //----------------------------------------------------------------------------
            indexListOfPokemons.push(c);
        }
    }

    for (let a = 0; a < maxSelectebelPokemons; a++) {


        if (indexListOfPokemons[a] != null)
            hiddenInputForSelectidCards[a].value = indexListOfPokemons[a];
        else
            hiddenInputForSelectidCards[a].value = -1;
    }

}, 100);