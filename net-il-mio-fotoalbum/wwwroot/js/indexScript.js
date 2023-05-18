function getPhotos() {
    console.log("ciao");
    axios.get("api/Api")
        .then((res) => {
            console.log(res);
            res.data.forEach((photo) => {
                document.getElementById("card-container").innerHTML += `
                    <div class="card" style = "width: 20%; min-width: 200px" >
                        <img class="card-image w-100" style="height: 180px; object-fit: contain;" src="/img/${photo.img}">
                        <div class="card-header">${photo.title}</div>
                        <div class="card-body overflow-hidden">${photo.description}</div>
                        <div class="d-flex justify-content-around px-1 pb-4">
                            <a class="btn btn-primary" href="/Photo/ShowPhoto/${photo.id}">S</a>
                            <a class="btn btn-primary" href="/Photo/EditPhoto/${photo.id}">E</a>
                            <form action="Photo/DeletePhoto/${photo.id}" method="post">
                                <input class="btn btn-danger" type="submit" value="-"/>
                            </form>
                        </div >
                    </div>
                `
            });
        })
        .catch((err) => console.log(err));
}