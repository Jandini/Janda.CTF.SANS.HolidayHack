// get elf text
setInterval(() => { console.log(document.getElementsByClassName("npc-username")[0].outerText); let e = document.getElementsByClassName("chat"); if (e && e.length) console.log(e[0].outerText); }, 1000);



// a bit more advanced...
let elfChat = new Set(); setInterval(() => { console.log(document.getElementsByClassName("npc-username")[0].outerText); let e = document.getElementsByClassName("chat"); let n = elfChat.size; if (e && e.length) { e[0].outerText.split("\n").forEach((line) => elfChat.add(line)); if (n == elfChat.size) { let chatText = ""; elfChat.forEach((value) => chatText += value + "\n"); console.log(chatText); elfChat.clear(); } } }, 500);



