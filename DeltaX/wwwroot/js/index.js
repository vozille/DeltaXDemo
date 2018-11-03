var MoviesVue = new Vue({
    el: "#movies-list",
    data: {
        movies: [],
        actors: [],
        producers: [],
        actor_id_details: {},
        producer_id_details: {}
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
        }
    }
})