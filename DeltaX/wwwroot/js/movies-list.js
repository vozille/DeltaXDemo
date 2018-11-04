var MoviesVue = new Vue({
    el: "#movies-list",
    data: {
        movies: [],
        actors: [],
        producers: [],
        actor_id_details: {},
        producer_id_details: {},
        selected_movie_to_edit: {
            Name: null,
            ActorIds: null,
            _id: null,
            Plot: null,
            PosterImage: null,
            ProducerId: null,
            YearOfRelease: null
        },
        is_editing_movie: false,
        poster_preview_url: null
    },
    created: function () {
        this.GetAllMovies();
        this.GetAllActors();
        this.GetAllProducers();
    },
    methods: {
        GetAllMovies: function () {
            var self = this;
            $.ajax({
                url: "/Movie/v1/GetAllMovieDetails",
                method: "GET",
                success: function (movie_list) {
                    self.movies = movie_list;
                }
            });
        },
        GetAllActors: function () {
            var self = this;
            $.ajax({
                url: "/Actor/v1/ListAllActors",
                method: "GET",
                success: function (actor_list) {
                    self.actors = actor_list;

                    actor_list.forEach(function (actor) {
                        self.actor_id_details[actor._id] = actor;
                    })
                }
            });
        },
        GetAllProducers: function () {
            var self = this;
            $.ajax({
                url: "/Producer/v1/ListAllProducers",
                method: "GET",
                success: function (producer_list) {
                    self.producers = producer_list;

                    producer_list.forEach(function (producer) {
                        self.producer_id_details[producer._id] = producer;
                    })
                }
            });
        },
        SelectMovieToEdit: function (movie) {
            this.selected_movie_to_edit.Name = movie.name;
            this.selected_movie_to_edit.ActorIds = movie.actorIds;
            this.selected_movie_to_edit._id = movie._id;
            this.selected_movie_to_edit.Plot = movie.plot;
            this.selected_movie_to_edit.PosterImage = movie.posterImage;
            this.selected_movie_to_edit.ProducerId = movie.producerId;
            this.selected_movie_to_edit.YearOfRelease = movie.yearOfRelease;
        },
        EditMovie: function () {
            var self = this;
            self.is_editing_movie = true;
            $.ajax({
                url: "/Movie/v1/EditMovieDetails",
                method: "PATCH",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(self.selected_movie_to_edit),
                success: function (data) {
                    alert("Movie Edited");
                    self.is_editing_movie = false;
                    $(".modal").modal('hide');
                    self.GetAllMovies();
                },
                error: function (data) {
                    alert("Error, please fill all details correctly")
                    self.is_editing_movie = false;
                }
            });
        },
        UploadMoviePoster: function (event) {

            var self = this;

            var fileData = event.target.files[0];
            var fileReader = new FileReader();
            fileReader.readAsDataURL(fileData);

            fileReader.onload = function (data) {
                self.poster_preview_url = data.target.result;
                self.selected_movie_to_edit.PosterImage = fileReader.result.split(',')[1];
            }
        }
    }
})