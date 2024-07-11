--
-- PostgreSQL database dump
--

-- Dumped from database version 14.3 (Debian 14.3-1.pgdg110+1)
-- Dumped by pg_dump version 14.3 (Debian 14.3-1.pgdg110+1)

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

ALTER TABLE ONLY public.user_role DROP CONSTRAINT fk_user_role_users_user_id;
ALTER TABLE ONLY public.user_role DROP CONSTRAINT fk_user_role_role_role_id;
ALTER TABLE ONLY public.status_card DROP CONSTRAINT fk_status_card_card_status_card_status_id;
ALTER TABLE ONLY public.status_card DROP CONSTRAINT fk_status_card_card_card_id;
ALTER TABLE ONLY public.payment DROP CONSTRAINT fk_payment_bill_bill_id;
ALTER TABLE ONLY public.country DROP CONSTRAINT fk_country_users_user_id;
ALTER TABLE ONLY public.card DROP CONSTRAINT fk_card_users_user_id;
ALTER TABLE ONLY public.bill DROP CONSTRAINT fk_bill_users_user_id;
ALTER TABLE ONLY public.bill DROP CONSTRAINT fk_bill_bill_type_bill_type_id;
ALTER TABLE ONLY public.bill DROP CONSTRAINT fk_bill_bill_status_bill_status_id;
ALTER TABLE ONLY public.bank_transfer DROP CONSTRAINT fk_bank_transfer_users_target_user_id;
ALTER TABLE ONLY public.bank_transfer DROP CONSTRAINT fk_bank_transfer_users_source_user_id;
ALTER TABLE ONLY public.bank_transfer DROP CONSTRAINT fk_bank_transfer_bank_transfer_status_bank_transfer_status_id;
ALTER TABLE ONLY public.ban DROP CONSTRAINT fk_ban_users_user_id;
ALTER TABLE ONLY public.ban DROP CONSTRAINT fk_ban_users_banned_by_id;
ALTER TABLE ONLY public.ban DROP CONSTRAINT fk_ban_ban_type_ban_type_id;
ALTER TABLE ONLY public.users DROP CONSTRAINT pk_users;
ALTER TABLE ONLY public.user_role DROP CONSTRAINT pk_user_role;
ALTER TABLE ONLY public.status_card DROP CONSTRAINT pk_status_card;
ALTER TABLE ONLY public.role DROP CONSTRAINT pk_role;
ALTER TABLE ONLY public.payment DROP CONSTRAINT pk_payment;
ALTER TABLE ONLY public.country DROP CONSTRAINT pk_country;
ALTER TABLE ONLY public.card_status DROP CONSTRAINT pk_card_status;
ALTER TABLE ONLY public.card DROP CONSTRAINT pk_card;
ALTER TABLE ONLY public.bill_type DROP CONSTRAINT pk_bill_type;
ALTER TABLE ONLY public.bill_status DROP CONSTRAINT pk_bill_status;
ALTER TABLE ONLY public.bill DROP CONSTRAINT pk_bill;
ALTER TABLE ONLY public.bank_transfer_status DROP CONSTRAINT pk_bank_transfer_status;
ALTER TABLE ONLY public.bank_transfer DROP CONSTRAINT pk_bank_transfer;
ALTER TABLE ONLY public.ban_type DROP CONSTRAINT pk_ban_type;
ALTER TABLE ONLY public.ban DROP CONSTRAINT pk_ban;
ALTER TABLE public.status_card ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.role ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.payment ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.country ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.card_status ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.card ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.bill_type ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.bill_status ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.bill ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.bank_transfer_status ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.bank_transfer ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.ban_type ALTER COLUMN id DROP DEFAULT;
ALTER TABLE public.ban ALTER COLUMN id DROP DEFAULT;
DROP TABLE public.users;
DROP TABLE public.user_role;
DROP SEQUENCE public.status_card_id_seq;
DROP TABLE public.status_card;
DROP SEQUENCE public.role_id_seq;
DROP TABLE public.role;
DROP SEQUENCE public.payment_id_seq;
DROP TABLE public.payment;
DROP SEQUENCE public.country_id_seq;
DROP TABLE public.country;
DROP SEQUENCE public.card_status_id_seq;
DROP TABLE public.card_status;
DROP SEQUENCE public.card_id_seq;
DROP TABLE public.card;
DROP SEQUENCE public.bill_type_id_seq;
DROP TABLE public.bill_type;
DROP SEQUENCE public.bill_status_id_seq;
DROP TABLE public.bill_status;
DROP SEQUENCE public.bill_id_seq;
DROP TABLE public.bill;
DROP SEQUENCE public.bank_transfer_status_id_seq;
DROP TABLE public.bank_transfer_status;
DROP SEQUENCE public.bank_transfer_id_seq;
DROP TABLE public.bank_transfer;
DROP SEQUENCE public.ban_type_id_seq;
DROP TABLE public.ban_type;
DROP SEQUENCE public.ban_id_seq;
DROP TABLE public.ban;
SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: ban; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.ban (
    id integer NOT NULL,
    from_date timestamp with time zone NOT NULL,
    to_date timestamp with time zone NOT NULL,
    reason text,
    ban_type_id integer NOT NULL,
    user_id uuid NOT NULL,
    banned_by_id uuid NOT NULL
);


ALTER TABLE public.ban OWNER TO admin;

--
-- Name: ban_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.ban_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ban_id_seq OWNER TO admin;

--
-- Name: ban_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.ban_id_seq OWNED BY public.ban.id;


--
-- Name: ban_type; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.ban_type (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.ban_type OWNER TO admin;

--
-- Name: ban_type_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.ban_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ban_type_id_seq OWNER TO admin;

--
-- Name: ban_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.ban_type_id_seq OWNED BY public.ban_type.id;


--
-- Name: bank_transfer; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.bank_transfer (
    id integer NOT NULL,
    amount double precision NOT NULL,
    created_at timestamp with time zone NOT NULL,
    source_user_id uuid NOT NULL,
    target_user_id uuid NOT NULL,
    bank_transfer_status_id integer NOT NULL
);


ALTER TABLE public.bank_transfer OWNER TO admin;

--
-- Name: bank_transfer_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.bank_transfer_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.bank_transfer_id_seq OWNER TO admin;

--
-- Name: bank_transfer_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.bank_transfer_id_seq OWNED BY public.bank_transfer.id;


--
-- Name: bank_transfer_status; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.bank_transfer_status (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.bank_transfer_status OWNER TO admin;

--
-- Name: bank_transfer_status_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.bank_transfer_status_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.bank_transfer_status_id_seq OWNER TO admin;

--
-- Name: bank_transfer_status_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.bank_transfer_status_id_seq OWNED BY public.bank_transfer_status.id;


--
-- Name: bill; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.bill (
    id integer NOT NULL,
    amount double precision NOT NULL,
    expiry_at timestamp with time zone NOT NULL,
    created_at timestamp with time zone NOT NULL,
    bill_status_id integer NOT NULL,
    bill_type_id integer NOT NULL,
    user_id uuid NOT NULL
);


ALTER TABLE public.bill OWNER TO admin;

--
-- Name: bill_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.bill_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.bill_id_seq OWNER TO admin;

--
-- Name: bill_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.bill_id_seq OWNED BY public.bill.id;


--
-- Name: bill_status; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.bill_status (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.bill_status OWNER TO admin;

--
-- Name: bill_status_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.bill_status_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.bill_status_id_seq OWNER TO admin;

--
-- Name: bill_status_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.bill_status_id_seq OWNED BY public.bill_status.id;


--
-- Name: bill_type; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.bill_type (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.bill_type OWNER TO admin;

--
-- Name: bill_type_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.bill_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.bill_type_id_seq OWNER TO admin;

--
-- Name: bill_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.bill_type_id_seq OWNED BY public.bill_type.id;


--
-- Name: card; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.card (
    id integer NOT NULL,
    created_at timestamp with time zone NOT NULL,
    deleted_at timestamp with time zone,
    card_number text NOT NULL,
    security_number smallint NOT NULL,
    valid_until timestamp with time zone NOT NULL,
    card_holder_name text NOT NULL,
    user_id uuid NOT NULL
);


ALTER TABLE public.card OWNER TO admin;

--
-- Name: card_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.card_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.card_id_seq OWNER TO admin;

--
-- Name: card_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.card_id_seq OWNED BY public.card.id;


--
-- Name: card_status; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.card_status (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.card_status OWNER TO admin;

--
-- Name: card_status_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.card_status_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.card_status_id_seq OWNER TO admin;

--
-- Name: card_status_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.card_status_id_seq OWNED BY public.card_status.id;


--
-- Name: country; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.country (
    id integer NOT NULL,
    name text NOT NULL,
    user_id uuid NOT NULL
);


ALTER TABLE public.country OWNER TO admin;

--
-- Name: country_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.country_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.country_id_seq OWNER TO admin;

--
-- Name: country_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.country_id_seq OWNED BY public.country.id;


--
-- Name: payment; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.payment (
    id integer NOT NULL,
    amount double precision NOT NULL,
    created_at timestamp with time zone NOT NULL,
    bill_id integer NOT NULL
);


ALTER TABLE public.payment OWNER TO admin;

--
-- Name: payment_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.payment_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.payment_id_seq OWNER TO admin;

--
-- Name: payment_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.payment_id_seq OWNED BY public.payment.id;


--
-- Name: role; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.role (
    id integer NOT NULL,
    name character varying(256),
    normalized_name character varying(256),
    concurrency_stamp text
);


ALTER TABLE public.role OWNER TO admin;

--
-- Name: role_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.role_id_seq OWNER TO admin;

--
-- Name: role_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.role_id_seq OWNED BY public.role.id;


--
-- Name: status_card; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.status_card (
    id integer NOT NULL,
    from_date timestamp with time zone NOT NULL,
    to_date timestamp with time zone,
    card_id integer NOT NULL,
    card_status_id integer NOT NULL
);


ALTER TABLE public.status_card OWNER TO admin;

--
-- Name: status_card_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.status_card_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.status_card_id_seq OWNER TO admin;

--
-- Name: status_card_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.status_card_id_seq OWNED BY public.status_card.id;


--
-- Name: user_role; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.user_role (
    user_id uuid NOT NULL,
    role_id integer NOT NULL
);


ALTER TABLE public.user_role OWNER TO admin;

--
-- Name: users; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.users (
    id uuid NOT NULL,
    firstname text NOT NULL,
    lastname text NOT NULL,
    birthdate timestamp with time zone NOT NULL,
    identity_document text NOT NULL,
    balance double precision NOT NULL,
    user_name character varying(256),
    normalized_user_name character varying(256),
    email character varying(256),
    normalized_email character varying(256),
    email_confirmed boolean NOT NULL,
    password_hash text,
    security_stamp text,
    concurrency_stamp text,
    phone_number text,
    phone_number_confirmed boolean NOT NULL,
    two_factor_enabled boolean NOT NULL,
    lockout_end timestamp with time zone,
    lockout_enabled boolean NOT NULL,
    access_failed_count integer NOT NULL
);


ALTER TABLE public.users OWNER TO admin;

--
-- Name: ban id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.ban ALTER COLUMN id SET DEFAULT nextval('public.ban_id_seq'::regclass);


--
-- Name: ban_type id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.ban_type ALTER COLUMN id SET DEFAULT nextval('public.ban_type_id_seq'::regclass);


--
-- Name: bank_transfer id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bank_transfer ALTER COLUMN id SET DEFAULT nextval('public.bank_transfer_id_seq'::regclass);


--
-- Name: bank_transfer_status id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bank_transfer_status ALTER COLUMN id SET DEFAULT nextval('public.bank_transfer_status_id_seq'::regclass);


--
-- Name: bill id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bill ALTER COLUMN id SET DEFAULT nextval('public.bill_id_seq'::regclass);


--
-- Name: bill_status id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bill_status ALTER COLUMN id SET DEFAULT nextval('public.bill_status_id_seq'::regclass);


--
-- Name: bill_type id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bill_type ALTER COLUMN id SET DEFAULT nextval('public.bill_type_id_seq'::regclass);


--
-- Name: card id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.card ALTER COLUMN id SET DEFAULT nextval('public.card_id_seq'::regclass);


--
-- Name: card_status id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.card_status ALTER COLUMN id SET DEFAULT nextval('public.card_status_id_seq'::regclass);


--
-- Name: country id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.country ALTER COLUMN id SET DEFAULT nextval('public.country_id_seq'::regclass);


--
-- Name: payment id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.payment ALTER COLUMN id SET DEFAULT nextval('public.payment_id_seq'::regclass);


--
-- Name: role id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.role ALTER COLUMN id SET DEFAULT nextval('public.role_id_seq'::regclass);


--
-- Name: status_card id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.status_card ALTER COLUMN id SET DEFAULT nextval('public.status_card_id_seq'::regclass);


--
-- Data for Name: ban; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.ban (id, from_date, to_date, reason, ban_type_id, user_id, banned_by_id) FROM stdin;
\.


--
-- Data for Name: ban_type; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.ban_type (id, name) FROM stdin;
\.


--
-- Data for Name: bank_transfer; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.bank_transfer (id, amount, created_at, source_user_id, target_user_id, bank_transfer_status_id) FROM stdin;
\.


--
-- Data for Name: bank_transfer_status; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.bank_transfer_status (id, name) FROM stdin;
\.


--
-- Data for Name: bill; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.bill (id, amount, expiry_at, created_at, bill_status_id, bill_type_id, user_id) FROM stdin;
\.


--
-- Data for Name: bill_status; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.bill_status (id, name) FROM stdin;
\.


--
-- Data for Name: bill_type; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.bill_type (id, name) FROM stdin;
\.


--
-- Data for Name: card; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.card (id, created_at, deleted_at, card_number, security_number, valid_until, card_holder_name, user_id) FROM stdin;
\.


--
-- Data for Name: card_status; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.card_status (id, name) FROM stdin;
\.


--
-- Data for Name: country; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.country (id, name, user_id) FROM stdin;
\.


--
-- Data for Name: payment; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.payment (id, amount, created_at, bill_id) FROM stdin;
\.


--
-- Data for Name: role; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.role (id, name, normalized_name, concurrency_stamp) FROM stdin;
\.


--
-- Data for Name: status_card; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.status_card (id, from_date, to_date, card_id, card_status_id) FROM stdin;
\.


--
-- Data for Name: user_role; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.user_role (user_id, role_id) FROM stdin;
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: admin
--

COPY public.users (id, firstname, lastname, birthdate, identity_document, balance, user_name, normalized_user_name, email, normalized_email, email_confirmed, password_hash, security_stamp, concurrency_stamp, phone_number, phone_number_confirmed, two_factor_enabled, lockout_end, lockout_enabled, access_failed_count) FROM stdin;
\.


--
-- Name: ban_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.ban_id_seq', 1, false);


--
-- Name: ban_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.ban_type_id_seq', 1, false);


--
-- Name: bank_transfer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.bank_transfer_id_seq', 1, false);


--
-- Name: bank_transfer_status_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.bank_transfer_status_id_seq', 1, false);


--
-- Name: bill_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.bill_id_seq', 1, false);


--
-- Name: bill_status_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.bill_status_id_seq', 1, false);


--
-- Name: bill_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.bill_type_id_seq', 1, false);


--
-- Name: card_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.card_id_seq', 1, false);


--
-- Name: card_status_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.card_status_id_seq', 1, false);


--
-- Name: country_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.country_id_seq', 1, false);


--
-- Name: payment_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.payment_id_seq', 1, false);


--
-- Name: role_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.role_id_seq', 1, false);


--
-- Name: status_card_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.status_card_id_seq', 1, false);


--
-- Name: ban pk_ban; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.ban
    ADD CONSTRAINT pk_ban PRIMARY KEY (id);


--
-- Name: ban_type pk_ban_type; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.ban_type
    ADD CONSTRAINT pk_ban_type PRIMARY KEY (id);


--
-- Name: bank_transfer pk_bank_transfer; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bank_transfer
    ADD CONSTRAINT pk_bank_transfer PRIMARY KEY (id);


--
-- Name: bank_transfer_status pk_bank_transfer_status; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bank_transfer_status
    ADD CONSTRAINT pk_bank_transfer_status PRIMARY KEY (id);


--
-- Name: bill pk_bill; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bill
    ADD CONSTRAINT pk_bill PRIMARY KEY (id);


--
-- Name: bill_status pk_bill_status; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bill_status
    ADD CONSTRAINT pk_bill_status PRIMARY KEY (id);


--
-- Name: bill_type pk_bill_type; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bill_type
    ADD CONSTRAINT pk_bill_type PRIMARY KEY (id);


--
-- Name: card pk_card; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT pk_card PRIMARY KEY (id);


--
-- Name: card_status pk_card_status; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.card_status
    ADD CONSTRAINT pk_card_status PRIMARY KEY (id);


--
-- Name: country pk_country; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.country
    ADD CONSTRAINT pk_country PRIMARY KEY (id);


--
-- Name: payment pk_payment; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT pk_payment PRIMARY KEY (id);


--
-- Name: role pk_role; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.role
    ADD CONSTRAINT pk_role PRIMARY KEY (id);


--
-- Name: status_card pk_status_card; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.status_card
    ADD CONSTRAINT pk_status_card PRIMARY KEY (id);


--
-- Name: user_role pk_user_role; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.user_role
    ADD CONSTRAINT pk_user_role PRIMARY KEY (user_id, role_id);


--
-- Name: users pk_users; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT pk_users PRIMARY KEY (id);


--
-- Name: ban fk_ban_ban_type_ban_type_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.ban
    ADD CONSTRAINT fk_ban_ban_type_ban_type_id FOREIGN KEY (ban_type_id) REFERENCES public.ban_type(id) ON DELETE CASCADE;


--
-- Name: ban fk_ban_users_banned_by_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.ban
    ADD CONSTRAINT fk_ban_users_banned_by_id FOREIGN KEY (banned_by_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: ban fk_ban_users_user_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.ban
    ADD CONSTRAINT fk_ban_users_user_id FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: bank_transfer fk_bank_transfer_bank_transfer_status_bank_transfer_status_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bank_transfer
    ADD CONSTRAINT fk_bank_transfer_bank_transfer_status_bank_transfer_status_id FOREIGN KEY (bank_transfer_status_id) REFERENCES public.bank_transfer_status(id) ON DELETE CASCADE;


--
-- Name: bank_transfer fk_bank_transfer_users_source_user_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bank_transfer
    ADD CONSTRAINT fk_bank_transfer_users_source_user_id FOREIGN KEY (source_user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: bank_transfer fk_bank_transfer_users_target_user_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bank_transfer
    ADD CONSTRAINT fk_bank_transfer_users_target_user_id FOREIGN KEY (target_user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: bill fk_bill_bill_status_bill_status_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bill
    ADD CONSTRAINT fk_bill_bill_status_bill_status_id FOREIGN KEY (bill_status_id) REFERENCES public.bill_status(id) ON DELETE CASCADE;


--
-- Name: bill fk_bill_bill_type_bill_type_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bill
    ADD CONSTRAINT fk_bill_bill_type_bill_type_id FOREIGN KEY (bill_type_id) REFERENCES public.bill_type(id) ON DELETE CASCADE;


--
-- Name: bill fk_bill_users_user_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.bill
    ADD CONSTRAINT fk_bill_users_user_id FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: card fk_card_users_user_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT fk_card_users_user_id FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: country fk_country_users_user_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.country
    ADD CONSTRAINT fk_country_users_user_id FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: payment fk_payment_bill_bill_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT fk_payment_bill_bill_id FOREIGN KEY (bill_id) REFERENCES public.bill(id) ON DELETE CASCADE;


--
-- Name: status_card fk_status_card_card_card_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.status_card
    ADD CONSTRAINT fk_status_card_card_card_id FOREIGN KEY (card_id) REFERENCES public.card(id) ON DELETE CASCADE;


--
-- Name: status_card fk_status_card_card_status_card_status_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.status_card
    ADD CONSTRAINT fk_status_card_card_status_card_status_id FOREIGN KEY (card_status_id) REFERENCES public.card_status(id) ON DELETE CASCADE;


--
-- Name: user_role fk_user_role_role_role_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.user_role
    ADD CONSTRAINT fk_user_role_role_role_id FOREIGN KEY (role_id) REFERENCES public.role(id) ON DELETE CASCADE;


--
-- Name: user_role fk_user_role_users_user_id; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.user_role
    ADD CONSTRAINT fk_user_role_users_user_id FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

