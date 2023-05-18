function getPhotos() {
    console.log("ciao");
    axios.get("https://localhost:7084/api/PhotoApi?filter=" + document.getElementById("searchBar").value)
        .then((res) => {
            document.getElementById("card-containerindex").innerHTML = "";
            res.data.forEach((photo) => {
                document.getElementById("card-containerindex").innerHTML += `
                    <div class="card" style = "width: 20%; min-width: 200px" >
                        <img class="card-image w-100" style="height: 180px; object-fit: contain;" src="/img/${photo.img}">
                        <div class="card-header">${photo.title}</div>
                        <div class="card-body overflow-hidden">${photo.description}</div>
                        <div class="d-flex justify-content-around px-1 pb-4">
                            <a class="btn btn-primary" href="/Photo/ShowPhoto/${photo.id}"><i class="fa-solid fa-magnifying-glass"></i></a>
                        </div >
                    </div>
                `
            });
        })
        .catch((err) => console.log(err));
}