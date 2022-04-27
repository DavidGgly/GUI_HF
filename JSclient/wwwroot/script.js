let racers = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:46187/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RacerCreated", (user, message) => {
        getdata();
    });

    connection.on("RacerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:46187/racer')
        .then(x => x.json())
        .then(y => {
            racers = y;
            console.log("racers", racers);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    racers.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.rname + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:46187/racer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('racername').value;
    fetch('http://localhost:46187/racer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { rname: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}