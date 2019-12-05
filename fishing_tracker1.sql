

DROP TABLE IF EXISTS  fishing_trip;

-- 
CREATE TABLE fishing_trip (
     id_trip SERIAL PRIMARY KEY,
	 fisher_name character varying(255),
    place character varying(255) NOT NULL,
	competition character varying NOT NULL,
    competition_name character varying(255),
	trip_start_time timestamp NOT NULL,
	trip_end_time timestamp
);



DROP TABLE IF EXISTS fishing_session;

CREATE TABLE fishing_session (
     id_session SERIAL PRIMARY KEY,
    session_start_time timestamp NOT NULL,
	session_end_time timestamp,
	fishing_style character varying(255),
	fk_lure integer,
	fk_trip integer,
	fk_catch integer
);



DROP TABLE IF EXISTS lure;

CREATE TABLE lure(
     id_lure SERIAL PRIMARY KEY NOT NULL,
    lure_name character varying(255),
	 lure_type character varying(255)

);

DROP TABLE IF EXISTS fish;

CREATE TABLE fish(
     id_fish SERIAL PRIMARY KEY NOT NULL,
    species character varying(255) NOT NULL
);

DROP TABLE IF EXISTS catch;

CREATE TABLE catch(
     id_catch SERIAL PRIMARY KEY NOT NULL,
    fk_fish integer,
	 fish_weight integer NOT NULL,
	fish_lenght integer NOT NULL,
	fish_time timestamp
	
);

DELETE FROM fish;

INSERT INTO fish VALUES (1, 'Hauki');
INSERT INTO fish VALUES (2, 'Kuha');
INSERT INTO fish VALUES (3, 'Ahven');


ALTER TABLE public.fishing_session
    ADD CONSTRAINT fk_trip_to_id_trip FOREIGN KEY (fk_trip)
    REFERENCES public.fishing_trip (id_trip);


ALTER TABLE ONLY public.fishing_session
    ADD CONSTRAINT fk_lure_to_id_lure FOREIGN KEY (fk_lure) REFERENCES public.lure(id_lure);
	
	ALTER TABLE ONLY public.fishing_session
    ADD CONSTRAINT fk_catch_to_id_catch FOREIGN KEY (fk_catch) REFERENCES public.catch(id_catch);

ALTER TABLE ONLY public.catch
    ADD CONSTRAINT fk_fish_to_id_fish FOREIGN KEY (fk_fish) REFERENCES public.fish(id_fish);




