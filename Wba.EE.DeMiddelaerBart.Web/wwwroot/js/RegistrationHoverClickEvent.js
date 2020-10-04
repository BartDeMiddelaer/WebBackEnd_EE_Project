
function ClickEvent(baceId, elementCount) {

    for (let i = 1; i <= elementCount; i++) {

        document.getElementById(`${baceId}${i}`).addEventListener('click', () => {

            for (let c = 1; c <= elementCount; c++) {

                if (c == i) {
                    document.getElementById(`${baceId}${c}`).style.backgroundColor = 'green';
                    document.getElementById(`selectit_${baceId}`).value = c;
                }
                else
                    document.getElementById(`${baceId}${c}`).style.backgroundColor = 'transparent';

            }
        });

        // hover --------------

        document.getElementById(`${baceId}${i}`).addEventListener('mouseenter', () => {
            if (document.getElementById(`${baceId}${i}`).style.backgroundColor != "green")
                document.getElementById(`${baceId}${i}`).style.backgroundColor = 'darkseagreen';
        });
        document.getElementById(`${baceId}${i}`).addEventListener('mouseleave', () => {
            if (document.getElementById(`${baceId}${i}`).style.backgroundColor != "green")
                document.getElementById(`${baceId}${i}`).style.backgroundColor = 'transparent';
        });

        // --------------------
    }

}