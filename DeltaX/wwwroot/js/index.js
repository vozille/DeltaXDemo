var MoviesVue = new Vue({
    el: "#movies-list",
    data: {
        movies: [],
        actors: [],
        producers: []
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
                url: "http://localhost:8000/Movie/v1/GetAllMovieDetails",
                method: "GET",
                success: function (movie_list) {
                    self.movies = movie_list;
                }
            });
        },
        GetAllActors: function () {
            var self = this;
            $.ajax({
                url: "http://localhost:8000/Actor/v1/ListAllActors",
                method: "GET",
                success: function (actor_list) {
                    self.actors = actor_list;
                }
            });
        },
        GetAllProducers: function () {
            var self = this;
            $.ajax({
                url: "http://localhost:8000/Producer/v1/ListAllProducers",
                method: "GET",
                success: function (producer_list) {
                    self.producers = producer_list;
                }
            });
        }
    }
})