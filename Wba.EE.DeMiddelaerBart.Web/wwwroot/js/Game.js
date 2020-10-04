// Game vars
var startGame = false; // <---- cheak om game te starten


// Boss propertys
var bossHpBar = document.getElementById('bossHpValue'); // toont Hp van de baas in %
var bossSkillCoolDownBar = document.getElementById('bossDpsCoundownValue'); // toont het aantal % van de cooldonwbar
var coolDownCounter = 0; // % bossSkillCoolDownBar is gebazeert op deze value
var bossMaxHP = bossCurentHP; // max hp van de baas 'bossCurentHP vint je in de view aangezien deze value van de server word gehaald

// ActivCard propertys
var indexOfSelectitCard = 0; // de index van de kaart waar op gecklikt is
var activCardMaxHp = document.getElementById(`card${indexOfSelectitCard}`).querySelector("#maxHp").value; // <--- Max Hp dat de pokemon kan hebben die geselecteert is op % te berekenen voor de HPBar
var activCardMaxMana = document.getElementById(`card${indexOfSelectitCard}`).querySelector("#maxMana").value;// <--- Max mana dat de pokemon kan hebben die geselecteert is op % te berekenen voor de ManaBar
var activCardCurentHp = document.getElementById(`card${indexOfSelectitCard}`).querySelector("#maxHp").value; // de huidige Hp wat er over blijft na dps weel op % te berekenen voor de HPBar
var activCardCurentMana = document.getElementById(`card${indexOfSelectitCard}`).querySelector("#maxMana").value; // de huidige Mana wat er over blijft na skill te gebruiken weel op % te berekenen voor de ManaBar
var activCardHpBar = document.getElementById('cardHpValue'); // voor het aanpassen aantal % van de HpBar
var activCardManaBar = document.getElementById('cardManaValue'); // voor het aanpassen aantal % van de ManaBar
var activCard = document.getElementById('inPutArticals'); // de kaart die actief is
var activCardName = document.getElementById(`card${indexOfSelectitCard}`).querySelector("#pokemonName").innerText; // de naam van de actieve kaart

// ActivSkillCards propertys
var indexOfClicktSkill = 0; // dient om de index door te geven van de skill die geklikt is aan gezien alle skill gerelateerde items in een Arry zit elk item heeft de zelvde index
var skills_Name = document.getElementById(`card${indexOfSelectitCard}`).querySelectorAll("#skillName"); // Arry skill names gebruik indexOfClicktSkill om gelijk te stellen met andere propertys
var skills_Dps = document.getElementById(`card${indexOfSelectitCard}`).querySelectorAll("#skillDps"); // Arry skill dps gebruik indexOfClicktSkill om gelijk te stellen met andere propertys
var skills_ManaCost = document.getElementById(`card${indexOfSelectitCard}`).querySelectorAll("#skillCost"); // Arry skill manacost gebruik indexOfClicktSkill om gelijk te stellen met andere propertys
var skills_Effect = document.getElementById(`card${indexOfSelectitCard}`).querySelectorAll("#skillEffect"); // Arry skill effect gebruik indexOfClicktSkill om gelijk te stellen met andere propertys
var skillsType = document.getElementById(`card${indexOfSelectitCard}`).querySelectorAll("#pokemonType"); // Arry skill type gebruik indexOfClicktSkill om gelijk te stellen met andere propertys
var deatCount = 0; // telt de aantal kaarten die dood zijn


// CardCkickEvents -----------------------------------------------------------------
// clicks on skills
for (let c = 0; c < 2; c++) {
     document.getElementById(`skillsCard${c}`).addEventListener('click', () => {
         if (startGame) {
            indexOfClicktSkill = c; // dient om de index door te geven van de skill die geklikt is aan gezien alle skill gerelateerde items in een Arry zit elk item heeft de zelvde index

            // berekening om de if te kunnen doen deelt door 2 om een int te krijgen
            let b = activCardCurentMana / 2;
            let a = skills_ManaCost[c].innerText / 2;       

            // als a<b :: als je dus genoeg mana hebt ::  , het hp van de geselecterde kaart niet 0 is en het zelvde voor baas
            if (a < b && activCardCurentHp > 0 && bossCurentHP != 0) {
                // trekt het mana die je moet consimeeren van het totaal
                activCardCurentMana = activCardCurentMana - skills_ManaCost[c].innerText;
                document.getElementById(`card${indexOfSelectitCard}`).querySelector("#pokemonMana")
                    .innerHTML = `  <div id="mpProsentIndicator" style="height:${activCardCurentMana / activCardMaxMana * 100}%;"></div>
                                    <p>${activCardCurentMana}</p>`;



                activCardManaBar.style.height = `${activCardCurentMana / activCardMaxMana * 100}%`;

                // bekijkt het aantal turns dat een skill doet
                let maxSkillsTurns = document.getElementById(`card${indexOfSelectitCard}`).querySelector("#skillTurnes").value;
                let turns = Math.floor(Math.random() * maxSkillsTurns);

                if (turns >= 2) BattelLog(`${activCardName} hits ${turns+1} times `)
                // animatie hier van ----> !!!!!!!!! SFX hier toevoegen later !!!!!!!!!!! 
                for (let i = 0; i <= turns; i++) {
                    setTimeout(() => {
                        DmgBoss(skills_Dps[c].innerText);
                    }, i*200);
                }         
            }
         }
    });
}

// als je op de kaarten in je deck ckilckt
//
// countOfCards is het aantal kaarten dat je mag hebben (@CountOfCardsToBattelWhit)
for (let i = 0; i < countOfCards; i++) { // countOfCards vint je in de view aangezien deze value van de server word gehaald @rasor
      
    document.getElementById(`card${i}`).addEventListener('click', () => {

        if (startGame) {
            // Clickt Card vars --------------------------------------------------------------------------
            let clicktCard_Img = document.getElementById(`card${i}`).querySelector("img").src;
            let clicktCard_MaxHp = document.getElementById(`card${i}`).querySelector("#maxHp").value;
            let clicktCard_Hp = document.getElementById(`card${i}`).querySelector("#pokemonHp").innerText;
            let clicktCard_MaxMana = document.getElementById(`card${i}`).querySelector("#maxMana").value;
            let clicktCard_Mana = document.getElementById(`card${i}`).querySelector("#pokemonMana").innerText;
            let clicktCard_Name = document.getElementById(`card${i}`).querySelector("#pokemonName").innerText;

            skills_Name = document.getElementById(`card${i}`).querySelectorAll("#skillName");
            skills_Dps = document.getElementById(`card${i}`).querySelectorAll("#skillDps");
            skills_ManaCost = document.getElementById(`card${i}`).querySelectorAll("#skillCost");
            skills_Effect = document.getElementById(`card${i}`).querySelectorAll("#skillEffect");
            skillsType = document.getElementById(`card${i}`).querySelectorAll("#pokemonType");
            // -------------------------------------------------------------------------------------------

            // FillingPokemonBattelCard ------------------------------------------------------------------
            // active kaart
            indexOfSelectitCard = i; // om de index door te geven van de kaart waar je op klickt
            // toekeningen
            activCardMaxHp = clicktCard_MaxHp;
            activCardMaxMana = clicktCard_MaxMana;
            activCardName = clicktCard_Name;
            activCardCurentHp = clicktCard_Hp;
            activCardCurentMana = clicktCard_Mana;

            // zet de hp en mp bars op het %
            activCardHpBar.style.height = `${clicktCard_Hp / clicktCard_MaxHp * 100}%`;
            activCardManaBar.style.height = `${clicktCard_Mana / clicktCard_MaxMana * 100}%`;

            document.getElementById('titelInfoCard').innerText = clicktCard_Name;
            document.getElementById('activCardImg').src = clicktCard_Img;
            // -------------------------------------------------------------------------------------------

            // SkillCardsFilling -------------------------------------------------------------------------
            //BG
            let backGroundSkillCards = document.getElementById(`skills`).querySelectorAll(".skillsCard");
            backGroundSkillCards[0].style.backgroundColor = document.getElementById(`card${i}`).style.backgroundColor;
            backGroundSkillCards[1].style.backgroundColor = document.getElementById(`card${i}`).style.backgroundColor;
            //Dps
            let dpsSkillCards = document.getElementById(`skills`).querySelectorAll("#skillsCardDps");
            dpsSkillCards[0].innerText = `Dps:${skills_Dps[0].innerText}`;
            dpsSkillCards[1].innerText = `Dps:${skills_Dps[1].innerText}`;
            //ManaCost
            let manaCostSkillCards = document.getElementById(`skills`).querySelectorAll("#skillsCardMana");
            manaCostSkillCards[0].innerText = `Mp:${skills_ManaCost[0].innerText}`;
            manaCostSkillCards[1].innerText = `Mp:${skills_ManaCost[1].innerText}`;
            //Effect
            let effectsSkillCards = document.getElementById(`skills`).querySelectorAll("#skillsCardEffect");
            effectsSkillCards[0].innerText = `${skills_Effect[0].innerText}`;
            effectsSkillCards[1].innerText = `${skills_Effect[1].innerText}`;
            //Name
            let namesSkillCards = document.getElementById(`skills`).querySelectorAll("#skillsCardName");
            namesSkillCards[0].innerText = `${skills_Name[0].innerText}`;
            namesSkillCards[1].innerText = `${skills_Name[1].innerText}`;

            // Log
            BattelLog(`You SwapOut ${document.getElementById('titelInfoCard').innerText} for ${clicktCard_Name}`);
        }
    });   
}

// gameLoop ------------------------------------------------------------------------
window.setInterval(() => {

    if (startGame) {

        // als je kaart geen hp heeft die je hebt gecelecteert doet LEAN_AND_MEAN niets
        if (document.getElementById(`card${indexOfSelectitCard}`).querySelector("#pokemonHp").innerText != 0) {
            if (BossSkillCoolDownCounter() >= 100) {
                // bereken dps dat hij kan doen zodat het niet onder 0 gaat
                let dpsItWatsToDo = Math.floor(Math.random() * 50);
                let hpLeft = document.getElementById(`card${indexOfSelectitCard}`).querySelector("#pokemonHp").innerText;
                let dpsItWilldo = dpsItWatsToDo < hpLeft ? dpsItWatsToDo : hpLeft;

                DmgActivCard(dpsItWilldo);
            }
        }
        // ManaRegen for alle the cards --------------------------------------------------
        if (activCardCurentHp > 0 && bossCurentHP != 0) {

            let cheakIfHonderitProcent = activCardManaBar.style.height.replace('%', '');
            if (cheakIfHonderitProcent > 100) activCardManaBar.style.height = '100%';

            if (cheakIfHonderitProcent < 100) {
                activCardCurentMana++;
                activCardManaBar.style.height = `${activCardCurentMana / activCardMaxMana * 100}%`;
            }
            // cards in deck regen
            for (let b = 0; b < countOfCards; b++) {

                let maxManoOfThisCard = document.getElementById(`card${b}`).querySelector("#maxMana").value;
                let valueInThisMoment = document.getElementById(`card${b}`).querySelector("#pokemonMana").innerText;
                let HpvalueInThisMoment = document.getElementById(`card${b}`).querySelector("#pokemonHp").innerText;

                let compleatInPrecent = valueInThisMoment / maxManoOfThisCard * 100;

                if (compleatInPrecent < 100 && HpvalueInThisMoment != 0 ) valueInThisMoment++;
                document.getElementById(`card${b}`).querySelector("#pokemonMana")
                    .innerHTML = `<div id="mpProsentIndicator" style="height:${compleatInPrecent}%;"></div> <p>${valueInThisMoment}</p>`
            }
        }
        // -------------------------------------------------------------------------------

        // GameStateCheak win or verliez -------------------------------------------------

        if (bossCurentHP <= 0) {
            document.getElementById('startGameCountdown')
                .innerHTML = `  <article id="inPutArticals" style="width:225px;border-color:Magenta;">
                                <div id="strockCard"></div>
                                <div id="strockCardInside"></div>
                                <h1 id="titelInfoCard">Play one more :D</h1>

                                <div id="inPutContent">                                                    
                                <p> Winner Winner Chicken Dinner :D !!!!!!</p>

                                </div>
                                </article>`;
        }

        for (let w = 0; w < countOfCards; w++) {
            if (document.getElementById(`card${w}`).querySelector("#pokemonHp").innerText <= 0) deatCount++

            if (deatCount == countOfCards) {
                document.getElementById('startGameCountdown')
                    .innerHTML = `  <article id="inPutArticals" style="width:225px;border-color:Magenta;">
                                    <div id="strockCard"></div>
                                    <div id="strockCardInside"></div>
                                    <h1 id="titelInfoCard">Play one more :D</h1>

                                    <div id="inPutContent">                                                    
                                    <p> :o :9 mmm .... you have lost.. :9 don't quit your job</p>

                                    </div>
                                    </article>`;
            }
        }
        // reset deatCount zo dat het weer getelt kan worden als je niet dood bent
        deatCount = 0;
        // -------------------------------------------------------------------------------

    }

}, 50);

// Functions -----------------------------------------------------------------------
function DmgActivCard(dmgValue) {

    // anemation ------------------------------
    activCard.style.backgroundColor = 'orangered';
    activCard.style.transform = `rotate(-${5}deg)`;

    setTimeout(() => {
        activCard.style.backgroundColor = 'linen';
        activCard.style.transform = `rotate(-${0}deg)`;
    }, 100);
    // ---------------------------------------

    if (dmgValue > 40) {
        BattelLog("CriticlDamage");
        dmgValue = 2 * dmgValue;
    }
    if (dmgValue == 0) BattelLog("LEAN Missis");

    let name = document.getElementById("titelInfoCard");
    BattelLog(`the LEAN boss deals ${dmgValue} Damage to ${name.innerText}`);


    //dps bekijk als het meer is en onder gaat
    if (activCardCurentHp != 0) {
        activCardCurentHp = activCardCurentHp - dmgValue;
        document.getElementById(`card${indexOfSelectitCard}`).querySelector("#pokemonHp")
            .innerHTML = ` <div id="hpProsentIndicator" style="height:${activCardCurentHp / activCardMaxHp * 100}%;"></div> <p>${activCardCurentHp}</p>`;
    }

    let hpProcent = activCardCurentHp / activCardMaxHp * 100;
    activCardHpBar.style.height = `${hpProcent}%`;
}
function BossSkillCoolDownCounter() {
    // als baas dood is doot hij niets
    if (bossCurentHP != 0) {
        // berekent % voor de bossSkillCoolDownBar
        coolDownCounter = coolDownCounter != 100
            ? coolDownCounter += 5
            : coolDownCounter = 0;
        // draws bossSkillCoolDownBar %
        bossSkillCoolDownBar.style.height = `${coolDownCounter}%`
    }
    // geeft coolDownCounter door om status te bekijken in IF en tekent het ook daar
    return coolDownCounter;
}
function BattelLog(log) {
    document.getElementById('battelLogs').innerHTML += `<p>${log}</p>`;

    let logBox = document.getElementById("battelLogs");
    logBox.scrollTop = logBox.scrollHeight;
}
function DmgBoss(dmgValue) {

    // anemation ------------------------------
    let bossCard = document.getElementById(`battelAction`).querySelectorAll("#inPutArticals")[1];
    bossCard.style.backgroundColor = 'orangered';
    bossCard.style.transform = `rotate(${5}deg)`;

    setTimeout(() => {
        bossCard.style.backgroundColor = 'linen';
        bossCard.style.transform = `rotate(${0}deg)`;
    }, 100);
    // ---------------------------------------

    //dps bekijk als het meer is en onder gaat

    let berekenDpsValue = bossCurentHP > dmgValue
        ?  dmgValue
        :  bossCurentHP;

    bossCurentHP = bossCurentHP - berekenDpsValue;
    bossHpBar.style.height = `${bossCurentHP / bossMaxHP * 100}%`;
    BattelLog(`${activCardName} used ${skills_Name[indexOfClicktSkill].innerText}, the attack deals ${berekenDpsValue} to LEAN`)
}
// ---------------------------------------------------------------------------------