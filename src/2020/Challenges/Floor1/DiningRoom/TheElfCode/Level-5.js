let request = elf.ask_munch(0)
var response = []
request.forEach((value) => {
    if (typeof (value) == "number") response.push(value);
});
elf.moveTo(munchkin[0]);
elf.tell_munch(response);
elf.moveUp(2);
