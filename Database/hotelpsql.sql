--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: guest; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.guest (
    id integer NOT NULL,
    name character varying NOT NULL,
    mobile bigint NOT NULL,
    email character varying,
    date_of_birth date NOT NULL,
    address character varying,
    gender smallint NOT NULL
);


ALTER TABLE public.guest OWNER TO postgres;

--
-- Name: guest_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.guest_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.guest_id_seq OWNER TO postgres;

--
-- Name: guest_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.guest_id_seq OWNED BY public.guest.id;


--
-- Name: room; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.room (
    id smallint NOT NULL,
    type smallint NOT NULL,
    size integer NOT NULL,
    price integer NOT NULL,
    staff_id integer
);


ALTER TABLE public.room OWNER TO postgres;

--
-- Name: room_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.room_id_seq
    AS smallint
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.room_id_seq OWNER TO postgres;

--
-- Name: room_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.room_id_seq OWNED BY public.room.id;


--
-- Name: schedule; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.schedule (
    id integer NOT NULL,
    check_in time with time zone NOT NULL,
    check_out time with time zone NOT NULL,
    guest_count smallint NOT NULL,
    price integer NOT NULL,
    created_at time with time zone NOT NULL,
    guest_id integer NOT NULL,
    room_id smallint NOT NULL
);


ALTER TABLE public.schedule OWNER TO postgres;

--
-- Name: schedule_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.schedule_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.schedule_id_seq OWNER TO postgres;

--
-- Name: schedule_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.schedule_id_seq OWNED BY public.schedule.id;


--
-- Name: staff; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.staff (
    id integer NOT NULL,
    name character varying NOT NULL,
    date_of_birth date NOT NULL,
    gender smallint NOT NULL,
    mobile bigint NOT NULL,
    shift smallint NOT NULL
);


ALTER TABLE public.staff OWNER TO postgres;

--
-- Name: staff_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.staff_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.staff_id_seq OWNER TO postgres;

--
-- Name: staff_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.staff_id_seq OWNED BY public.staff.id;


--
-- Name: guest id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.guest ALTER COLUMN id SET DEFAULT nextval('public.guest_id_seq'::regclass);


--
-- Name: room id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.room ALTER COLUMN id SET DEFAULT nextval('public.room_id_seq'::regclass);


--
-- Name: schedule id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedule ALTER COLUMN id SET DEFAULT nextval('public.schedule_id_seq'::regclass);


--
-- Name: staff id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.staff ALTER COLUMN id SET DEFAULT nextval('public.staff_id_seq'::regclass);


--
-- Data for Name: guest; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.guest (id, name, mobile, email, date_of_birth, address, gender) FROM stdin;
2	Durga	9848586879	durga@gmail.com	1999-10-24	Balnagar	1
3	Seshu	9848050292	seshu@gmail.com	1970-01-02	Kphb	2
4	Balaji	9848586872	balaji@gmail.com	1971-05-05	Balnagar	2
1	Swathi	7868584821	swathi@gmail.com	2022-03-15	Kphb	1
\.


--
-- Data for Name: room; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.room (id, type, size, price, staff_id) FROM stdin;
2	4	2000	15000	2
3	2	2000	16000	3
4	2	2000	18000	4
1	1	2000	80000	1
\.


--
-- Data for Name: schedule; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.schedule (id, check_in, check_out, guest_count, price, created_at, guest_id, room_id) FROM stdin;
2	19:10:25-07	19:10:25-07	1	45000	01:03:25-07	2	2
4	19:10:25-07	19:10:25-07	1	50000	01:03:25-07	4	4
3	10:40:00.653+05:30	10:40:00.653+05:30	5	60000	13:56:53+05:53:28	3	3
\.


--
-- Data for Name: staff; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.staff (id, name, date_of_birth, gender, mobile, shift) FROM stdin;
2	kavya	1978-09-10	1	9845679231	2
3	Indhu	1995-06-12	1	9845679654	3
4	Baby	1996-08-02	1	9845679653	4
1	Navya	2000-01-02	1	7564329156	2
\.


--
-- Name: guest_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.guest_id_seq', 1, true);


--
-- Name: room_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.room_id_seq', 1, false);


--
-- Name: schedule_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.schedule_id_seq', 3, true);


--
-- Name: staff_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.staff_id_seq', 1, false);


--
-- Name: guest guest_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.guest
    ADD CONSTRAINT guest_pkey PRIMARY KEY (id);


--
-- Name: room room_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.room
    ADD CONSTRAINT room_pkey PRIMARY KEY (id);


--
-- Name: schedule schedule_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT schedule_pkey PRIMARY KEY (id);


--
-- Name: staff staff_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.staff
    ADD CONSTRAINT staff_pkey PRIMARY KEY (id);


--
-- Name: schedule guest_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT guest_id FOREIGN KEY (guest_id) REFERENCES public.guest(id) NOT VALID;


--
-- Name: schedule room_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedule
    ADD CONSTRAINT room_id FOREIGN KEY (room_id) REFERENCES public.room(id) NOT VALID;


--
-- Name: room staff_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.room
    ADD CONSTRAINT staff_id FOREIGN KEY (staff_id) REFERENCES public.staff(id) NOT VALID;


--
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: postgres
--

GRANT USAGE ON SCHEMA public TO hotelpsql_admin;


--
-- Name: TABLE guest; Type: ACL; Schema: public; Owner: postgres
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public.guest TO hotelpsql_admin;


--
-- Name: SEQUENCE guest_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.guest_id_seq TO hotelpsql_admin;


--
-- Name: TABLE room; Type: ACL; Schema: public; Owner: postgres
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public.room TO hotelpsql_admin;


--
-- Name: SEQUENCE room_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.room_id_seq TO hotelpsql_admin;


--
-- Name: TABLE schedule; Type: ACL; Schema: public; Owner: postgres
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public.schedule TO hotelpsql_admin;


--
-- Name: SEQUENCE schedule_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.schedule_id_seq TO hotelpsql_admin;


--
-- Name: TABLE staff; Type: ACL; Schema: public; Owner: postgres
--

GRANT SELECT,INSERT,DELETE,UPDATE ON TABLE public.staff TO hotelpsql_admin;


--
-- Name: SEQUENCE staff_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.staff_id_seq TO hotelpsql_admin;


--
-- Name: DEFAULT PRIVILEGES FOR SEQUENCES; Type: DEFAULT ACL; Schema: public; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres IN SCHEMA public GRANT ALL ON SEQUENCES  TO hotelpsql_admin;


--
-- Name: DEFAULT PRIVILEGES FOR TABLES; Type: DEFAULT ACL; Schema: public; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres IN SCHEMA public GRANT SELECT,INSERT,DELETE,UPDATE ON TABLES  TO hotelpsql_admin;


--
-- PostgreSQL database dump complete
--

